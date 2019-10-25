namespace Osu_Parser
{
    partial class OsuParser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OsuSongFolder = new System.Windows.Forms.Button();
            this.DirectoryToMove = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.CancelOsuParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OsuSongFolder
            // 
            this.OsuSongFolder.Location = new System.Drawing.Point(370, 77);
            this.OsuSongFolder.Name = "OsuSongFolder";
            this.OsuSongFolder.Size = new System.Drawing.Size(142, 77);
            this.OsuSongFolder.TabIndex = 0;
            this.OsuSongFolder.Text = "Choose Osu Directory";
            this.OsuSongFolder.UseVisualStyleBackColor = true;
            this.OsuSongFolder.Visible = false;
            this.OsuSongFolder.Click += new System.EventHandler(this.OsuDirectory_Click);
            // 
            // DirectoryToMove
            // 
            this.DirectoryToMove.Location = new System.Drawing.Point(12, 77);
            this.DirectoryToMove.Name = "DirectoryToMove";
            this.DirectoryToMove.Size = new System.Drawing.Size(142, 77);
            this.DirectoryToMove.TabIndex = 1;
            this.DirectoryToMove.Text = "Choose Directory to Put Files";
            this.DirectoryToMove.UseVisualStyleBackColor = true;
            this.DirectoryToMove.Click += new System.EventHandler(this.DirectorytoPut_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 160);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(500, 23);
            this.ProgressBar.TabIndex = 2;
            this.ProgressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 186);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 100);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelOsuParse
            // 
            this.CancelOsuParse.Location = new System.Drawing.Point(192, 77);
            this.CancelOsuParse.Name = "CancelOsuParse";
            this.CancelOsuParse.Size = new System.Drawing.Size(142, 77);
            this.CancelOsuParse.TabIndex = 4;
            this.CancelOsuParse.Text = "Cancel";
            this.CancelOsuParse.UseVisualStyleBackColor = true;
            this.CancelOsuParse.Visible = false;
            this.CancelOsuParse.Click += new System.EventHandler(this.CancelOsuParse_Click);
            // 
            // OsuParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 318);
            this.Controls.Add(this.CancelOsuParse);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.DirectoryToMove);
            this.Controls.Add(this.OsuSongFolder);
            this.Name = "OsuParser";
            this.Text = "Osu Parser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OsuSongFolder;
        private System.Windows.Forms.Button DirectoryToMove;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button CancelOsuParse;
    }
}

