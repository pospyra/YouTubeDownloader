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

        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isPlaylist = radioButtonPlaylist.Checked;
        }
    }
}
