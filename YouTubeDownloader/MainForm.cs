using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;

namespace YouTubeDownloader
{
    public partial class MainForm : Form
    {
        private bool isPlaylist;

        public MainForm()
        {
            InitializeComponent();
            InitializeQualityComboBox();
            InitializeRadioButtons();
        }

        private void InitializeRadioButtons()
        {
            radioButtonPlaylist.Checked = true;
            isPlaylist = true;

            radioButtonPlaylist.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonVideo.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void InitializeQualityComboBox()
        {
            var qualities = new[] { "720p", "1080p (HD)", "1440p (HD)", "2160p (4K)" };
            comboBoxQuality.Items.AddRange(qualities);
            comboBoxQuality.SelectedIndex = 1; // По умолчанию 1080p
        }

        private async void buttonDownload_Click(object sender, EventArgs e)
        {
            var url = textBoxUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Пожалуйста, введите ссылку.");
                return;
            }

            using var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            var basePath = folderBrowserDialog.SelectedPath;
            labelStatus.Text = "Загрузка...";

            try
            {
                var youtube = new YoutubeClient();
                if (isPlaylist)
                {
                    await DownloadPlaylistAsync(youtube, url, basePath);
                }
                else
                {
                    await DownloadVideoAsync(youtube, url, basePath);
                }
                labelStatus.Text = "Загрузка завершена!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при скачивании: {ex.Message}");
            }
        }

        private async Task DownloadPlaylistAsync(YoutubeClient youtube, string playlistUrl, string basePath)
        {
            var playlist = await youtube.Playlists.GetAsync(playlistUrl);
            var playlistVideos = youtube.Playlists.GetVideosAsync(playlist.Id);

            var playlistFolderPath = Path.Combine(basePath, playlist.Title);
            Directory.CreateDirectory(playlistFolderPath);

            var downloadTasks = new List<Task>();
            await foreach (var playlistVideo in playlistVideos)
            {
                var video = await youtube.Videos.GetAsync(playlistVideo.Id);
                downloadTasks.Add(ProcessVideoAsync(youtube, video, playlistFolderPath));
            }

            await Task.WhenAll(downloadTasks);
        }

        private async Task DownloadVideoAsync(YoutubeClient youtube, string videoUrl, string basePath)
        {
            var video = await youtube.Videos.GetAsync(videoUrl);
            await ProcessVideoAsync(youtube, video, basePath);
        }

        private async Task ProcessVideoAsync(YoutubeClient youtube, Video video, string folderPath)
        {
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id).AsTask();
            var selectedQuality = comboBoxQuality.SelectedItem?.ToString() ?? "1080p";
            var maxHeight = ParseQualityToHeight(selectedQuality);

            var bestVideoStream = streamManifest.GetVideoStreams()
                .Where(s => s.VideoQuality.MaxHeight <= maxHeight)
                .OrderByDescending(s => s.VideoQuality.MaxHeight)
                .FirstOrDefault();

            var bestAudioStream = streamManifest.GetAudioStreams()
                .OrderByDescending(s => s.Bitrate)
                .FirstOrDefault();

            if (bestVideoStream == null || bestAudioStream == null) return;

            var videoPath = Path.Combine(folderPath, $"{video.Title}_video.mp4");
            var audioPath = Path.Combine(folderPath, $"{video.Title}_audio.mp3");

            var videoDownloadTask = youtube.Videos.Streams.DownloadAsync(bestVideoStream, videoPath).AsTask();
            var audioDownloadTask = youtube.Videos.Streams.DownloadAsync(bestAudioStream, audioPath).AsTask();

            await Task.WhenAll(videoDownloadTask, audioDownloadTask);

            CombineVideoAndAudio(videoPath, audioPath, folderPath, video.Title);
        }

        private void CombineVideoAndAudio(string videoPath, string audioPath, string folderPath, string title)
        {
            var combinedPath = Path.Combine(folderPath, $"{title}.mp4");
            var ffmpeg = new NReco.VideoConverter.FFMpegConverter();
            ffmpeg.Invoke($"-i \"{videoPath}\" -i \"{audioPath}\" -c:v copy -c:a aac \"{combinedPath}\"");

            File.Delete(videoPath);
            File.Delete(audioPath);
        }

        private int ParseQualityToHeight(string quality) => quality switch
        {
            "720p" => 720,
            "1080p (HD)" => 1080,
            "1440p (HD)" => 1440,
            "2160p (4K)" => 2160,
            _ => 1080
        };

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isPlaylist = radioButtonPlaylist.Checked;
        }
    }
}
