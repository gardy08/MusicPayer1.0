using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPayer1._0
{
    public partial class Form1 : Form
    {
        
        List<Songs> _songs; //we call the class here like a global variable 
        public Form1()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //acces to the files 
            //button to add song and multiselect option

            OpenFileDialog dialog = new OpenFileDialog(); //access to the data source and open the files
            dialog.Multiselect = true; 

            if(dialog.ShowDialog()== DialogResult.OK)
            {
                AddsongsToList( dialog.SafeFileNames.ToList(),
                     dialog.FileNames.ToList());
       

                //add song to the list

            }
        }

        private void AddsongsToList(List<string> names, List<string> paths) //to add songs and we call the method existed song directly 
        {
            if (_songs == null)
            {
                _songs = new List<Songs>();
            }

            foreach(var item in names) //if the songs already exist 
            {
                // if songs exist or not 

                if (!ExistOnList(item))
                    _songs.Add(new Songs(item, GetPath(item, paths)));
            }

            /* I use song list as a data source, to see the output on the screen if the 
             * song was added or no so the user can see it */
            RefreshList();
        }

        private bool ExistOnList(string song) //new parameter to verify if the song exist or not 
        {
            bool exist = false;
            foreach(var item in _songs)
            {
                if (item.Name == song)
                    exist = true;
            }

            return exist;
        }
        private string GetPath(string filename, List<string> songspath = null)
        {
            string actualPath = string.Empty;

            if (songspath == null)
            {
                foreach (var song in _songs)
                {
                    if (song.Name == filename)
                        actualPath = song.Path;
                }
            }
            else
            {
                foreach (var path in songspath)
                {
                    if (path.Contains(filename))
                        actualPath = path;
                }
            }

            return actualPath;
        }
        private void SongsList_DoubleClick(object sender, EventArgs e)
        {
           
            axWindowsMediaPlayer1.URL = GetPath(SongsList.Text);
            // i remove it by mistake 
        }

        private void SongsList_DoubleClick_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = GetPath(SongsList.Text);
            
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            Songs sonToRemove = null; // we initialize the variabe with null 

            foreach(var song in _songs)
            {
                if (song.Name == SongsList.Text)
                    sonToRemove = song;
            }

            if (sonToRemove != null)
                _songs.Remove(sonToRemove);

            RefreshList();
        }

        private void RefreshList() //this new method is to refresh, if something was remove or was added
        {
            List<string> songsnames = new List<string>();
            foreach (var item in _songs)
                songsnames.Add(item.Name);

            SongsList.DataSource = null; //data source this where we storage all the songs 
            SongsList.DataSource = songsnames;
        }
    }
}
