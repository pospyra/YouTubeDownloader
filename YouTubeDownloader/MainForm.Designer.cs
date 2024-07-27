namespace YouTubeDownloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            textBoxUrl = new TextBox();
            buttonDownload = new Button();
            labelStatus = new Label();
            comboBoxQuality = new ComboBox();
            label1 = new Label();
            radioButtonPlaylist = new RadioButton();
            radioButtonVideo = new RadioButton();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxUrl
            // 
            textBoxUrl.BackColor = Color.WhiteSmoke;
            textBoxUrl.BorderStyle = BorderStyle.FixedSingle;
            textBoxUrl.Font = new Font("Sitka Small", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUrl.Location = new Point(131, 55);
            textBoxUrl.Margin = new Padding(3, 4, 3, 4);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(415, 26);
            textBoxUrl.TabIndex = 0;
            // 
            // buttonDownload
            // 
            buttonDownload.BackColor = Color.Snow;
            buttonDownload.FlatStyle = FlatStyle.Flat;
            buttonDownload.Font = new Font("Sitka Small", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDownload.ForeColor = Color.Black;
            buttonDownload.Location = new Point(401, 101);
            buttonDownload.Margin = new Padding(3, 4, 3, 4);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(145, 32);
            buttonDownload.TabIndex = 1;
            buttonDownload.Text = "Скачать";
            buttonDownload.UseVisualStyleBackColor = false;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.BackColor = Color.Transparent;
            labelStatus.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelStatus.ForeColor = SystemColors.Control;
            labelStatus.Location = new Point(353, 152);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(0, 19);
            labelStatus.TabIndex = 3;
            // 
            // comboBoxQuality
            // 
            comboBoxQuality.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQuality.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxQuality.FormattingEnabled = true;
            comboBoxQuality.Location = new Point(155, 42);
            comboBoxQuality.Margin = new Padding(3, 4, 3, 4);
            comboBoxQuality.Name = "comboBoxQuality";
            comboBoxQuality.Size = new Size(126, 23);
            comboBoxQuality.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(151, 18);
            label1.Name = "label1";
            label1.Size = new Size(130, 18);
            label1.TabIndex = 5;
            label1.Text = "Макс. разрешение";
            // 
            // radioButtonPlaylist
            // 
            radioButtonPlaylist.AutoSize = true;
            radioButtonPlaylist.BackColor = Color.Transparent;
            radioButtonPlaylist.Checked = true;
            radioButtonPlaylist.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonPlaylist.ForeColor = SystemColors.Control;
            radioButtonPlaylist.Location = new Point(14, 14);
            radioButtonPlaylist.Name = "radioButtonPlaylist";
            radioButtonPlaylist.Size = new Size(90, 22);
            radioButtonPlaylist.TabIndex = 6;
            radioButtonPlaylist.TabStop = true;
            radioButtonPlaylist.Text = "Плейлист";
            radioButtonPlaylist.UseVisualStyleBackColor = false;
            // 
            // radioButtonVideo
            // 
            radioButtonVideo.AutoSize = true;
            radioButtonVideo.BackColor = Color.Transparent;
            radioButtonVideo.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point);
            radioButtonVideo.ForeColor = SystemColors.Control;
            radioButtonVideo.Location = new Point(14, 39);
            radioButtonVideo.Name = "radioButtonVideo";
            radioButtonVideo.Size = new Size(67, 22);
            radioButtonVideo.TabIndex = 7;
            radioButtonVideo.Text = "Видео";
            radioButtonVideo.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(radioButtonPlaylist);
            panel1.Controls.Add(radioButtonVideo);
            panel1.Controls.Add(comboBoxQuality);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(260, 213);
            panel1.Name = "panel1";
            panel1.Size = new Size(286, 148);
            panel1.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(671, 373);
            Controls.Add(panel1);
            Controls.Add(labelStatus);
            Controls.Add(buttonDownload);
            Controls.Add(textBoxUrl);
            Font = new Font("Sitka Small", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTubeDownloader";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUrl;
        private Button buttonDownload;
        private Label labelStatus;
        private ComboBox comboBoxQuality;
        private Label label1;
        private RadioButton radioButtonPlaylist;
        private RadioButton radioButtonVideo;
        private Panel panel1;
    }
}
