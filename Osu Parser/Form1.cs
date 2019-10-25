using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Osu_Parser
{
    public partial class OsuParser : Form
    {
        private string DirectorytoPut, SongsPath;
        public OsuParser()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += ParseFiles;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;  //Tell the user how the process went
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true; //Allow for the process to be cancelled
        }

        private void ParseFiles(object sender, System.ComponentModel.DoWorkEventArgs e){             
            List<string> allSongFolderPaths = new List<string>(Directory.GetDirectories(SongsPath));
            List<Song_Details> allSongs = new List<Song_Details>() { };
            for (int folderNo = 0; folderNo < allSongFolderPaths.Count(); folderNo++){           
                string[] osuFiles = Directory.GetFiles(allSongFolderPaths[folderNo].ToString() + @"\", "*.osu");
                HashSet<string> title = new HashSet<string>() { }, artist = new HashSet<string>() { }, songpaths = new HashSet<string>() { },
                        version = new HashSet<string>() { }, picture = new HashSet<string>() { };
                for (int osuFileNo = 0; osuFileNo < osuFiles.Count(); osuFileNo++){
                    string[] lines = File.ReadAllLines(osuFiles[osuFileNo]);         
                    for (int lineNo = 0; lineNo < lines.Count(); lineNo++){
                        if (lines[lineNo].Contains("AudioFilename:")) { string[] temp = lines[lineNo].Split(':'); songpaths.Add((allSongFolderPaths[folderNo] + @"\" + temp[1].TrimStart(' '))); }
                        if (lines[lineNo].Contains("Title:")) { string[] temp = lines[lineNo].Split(':'); title.Add(temp[1]); }
                        if (lines[lineNo].Contains("Artist:")) { string[] temp = lines[lineNo].Split(':'); artist.Add(temp[1]); }
                        if (lines[lineNo].Contains("Version:")) { string[] temp = lines[lineNo].Split(':'); version.Add(temp[1]); }
                        if (lines[lineNo].Contains("0,0,\"")) { string[] temp = lines[lineNo].Split('"'); picture.Add(allSongFolderPaths[folderNo] + @"\" + temp[1]); break; }
                    }
                    
                    
                }
                List<string> allTitles = title.ToList(), allArtists = artist.ToList(), allSongPaths = songpaths.ToList(), allVersions = version.ToList(),
                        allPictures = picture.ToList();
                if (allPictures.Count() == 0) { allPictures.Add("Default"); }
                else if (!File.Exists(allPictures[0])) { allPictures[0] = "Default"; }
                for (int actualSongs = 0; actualSongs < songpaths.Count; actualSongs++){
                    allSongs.Add(new Song_Details(allTitles[0], allArtists[0], allSongPaths[actualSongs], allPictures[0]));
                }
                /*for (int songsNo = 0; songsNo < songsinFolder.Count(); songsNo++){
                    string sourceFile = System.IO.Path.Combine(allSongFolderPaths[folderNo], songsinFolder[songsNo].SongOldName);
                    string destFile = System.IO.Path.Combine(@DirectorytoPut, songsinFolder[songsNo].SongNewName);
                    allPaths.Add(destFile);
                    System.IO.File.Copy(sourceFile, destFile, true);
                    var tfile = TagLib.File.Create(destFile);
                    tfile.Tag.Title = songsinFolder[songsNo].Name;
                    tfile.Tag.Artists = songsinFolder[songsNo].Artist.Split(',');
                    tfile.Tag.AlbumArtists = songsinFolder[songsNo].Artist.Split(',');
                    tfile.Tag.Performers = songsinFolder[songsNo].Artist.Split(',');
                    TagLib.Picture pic = new TagLib.Picture();
                    pic.Type = TagLib.PictureType.FrontCover;
                    pic.Description = "Cover";
                    pic.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
                    MemoryStream ms = new MemoryStream();
                    songsinFolder[songsNo].Art.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    pic.Data = TagLib.ByteVector.FromStream(ms);
                    if (tfile.Tag.Pictures.Count() != 0) { tfile.Tag.Pictures = new TagLib.IPicture[] { pic }; }
                    else { tfile.Tag.Pictures = new TagLib.IPicture[] { pic }; }
                    tfile.Save();
                }*/
                float Progress = ((float)folderNo + 1) / ((float)allSongFolderPaths.Count());                            
                Progress = Progress * 100f;
                int realprogress = (int)Progress;
                backgroundWorker1.ReportProgress(realprogress);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                
            }
            Console.WriteLine(allSongs.Count());
            this.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                SongsPath = null;
                ProgressBar.Visible = false;
                CancelOsuParse.Visible = false;
                DirectoryToMove.Visible = true;
                OsuSongFolder.Visible = true;
            });

            System.Windows.Forms.MessageBox.Show("Files found: " + allSongFolderPaths.Count.ToString() + "\n" + "Songs: ", "Message");
        }
        private void OsuDirectory_Click(object sender, EventArgs e){
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    SongsPath = fbd.SelectedPath;
                    ProgressBar.Visible = true;
                    CancelOsuParse.Visible = true;
                    lblStatus.Visible = true;
                    DirectoryToMove.Visible = false;
                    OsuSongFolder.Visible = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            
        }

        private void DirectorytoPut_Click(object sender, EventArgs e){
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DirectorytoPut = fbd.SelectedPath;
                    OsuSongFolder.Visible = true;
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e){
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void CancelOsuParse_Click(object sender, EventArgs e){
            if (backgroundWorker1.IsBusy){
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e){
            if (e.Cancelled){
                lblStatus.Text = "Process was cancelled";
            }
            else if (e.Error != null){
                lblStatus.Text = "There was an error running the process. The thread aborted";
            }
            else{
                lblStatus.Text = "Process was completed";
            }
        }

        private List<string> GetAllSongPaths(string osuFolder) {
            List<string> allSongFolderPaths = new List<string>(Directory.GetDirectories(SongsPath));
            List<Song_Details> allSongs = new List<Song_Details>() { };



        }
    }
}
