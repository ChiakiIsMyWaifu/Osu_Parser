using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Osu_Parser{
    class Song_Details: IEquatable<Song_Details>{
        private string name;
        private string artist;
        private string songpath;
        private string songoldname;
        private string songnewname;
        private string id;
        private Bitmap art = null;
        private string artpath = "Default";
        private float songlength;
        private string songhash;

        private string checkIllegal(string StringToCheck)
        {
            List<char> toTest = new List<char>(StringToCheck);
            string FinalString = "";
            for (int i = 0; i < toTest.Count; i++)
            {
                if (toTest[i] == '/' || toTest[i] == ':' || toTest[i].ToString() == @"\" || toTest[i] == '|' || toTest[i] == '*' || toTest[i] == '?' || toTest[i] == '"' || toTest[i] == '<' || toTest[i] == '>') { continue; }
                else { FinalString += toTest[i]; }
            }
            return FinalString;

        }

        public Bitmap getCenter(){
            if (artpath == "Default")
            {
                return Properties.Resources.xOf4lxBy_400x400;
            }
            else{
                Bitmap imagetoCrop = Image.FromFile(artpath) as Bitmap;
                int height = imagetoCrop.Height, width = imagetoCrop.Width;
                int offset = (width - height) / 2;
                Rectangle cropRect = new Rectangle(new Point(offset, 0), new Size(height, height));
                Bitmap centerart = new Bitmap(height, height);
                using (Graphics g = Graphics.FromImage(centerart)){
                    g.DrawImage(imagetoCrop, new Rectangle(0, 0, centerart.Width, centerart.Height),
                                     cropRect,
                                     GraphicsUnit.Pixel);
                }
                return centerart;
            }
        }

        public bool Equals(Song_Details other){
            return false;
        }

        public Song_Details(string n, string a, string p, string ar){
            name = n;
            artist = a;
            songpath = @p;
            songoldname = @Path.GetFileName(songpath);
            songnewname = checkIllegal(name + " - " + artist +".mp3");
            artpath = ar;
            songlength = 
     
        }
        public string Name{
            get
            {
                return name;
            }
        }
        public Bitmap Art
        {
            get
            {
                return art;
            }
        }
        public string ID
        {
            get
            {
                return id;
            }
        }
        public string Artist
        {
            get
            {
                return artist;
            }
        }
        public string SongPath
        {
            get
            {
                return songpath;
            }
        }
        public string SongOldName
        {
            get
            {
                return songoldname;
            }
        }
        public string SongNewName
        {
            get
            {
                return songnewname;
            }
        }





    }
}
