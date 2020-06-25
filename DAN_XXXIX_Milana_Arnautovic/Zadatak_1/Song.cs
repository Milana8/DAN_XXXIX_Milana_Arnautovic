using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Song
    {

        public int ID { get; set; }
        public string Author { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Duration { get; set; }

        public Song(int iD, string author, string songTitle, TimeSpan duration)
        {
            ID = iD;
            Author = author;
            SongTitle = songTitle;
            Duration = duration;
        }

        public static List<Song> ListSongs { get; set; }

        static Song()
        {
            ListSongs = new List<Song>();
        }

        public static Song FromFileToObject(string tekst)
        {
            string[] red = tekst.Split(',');

            if (red.Length != 4)
            {
                Console.WriteLine("Error " + tekst);

            }

            int iD = Int32.Parse(red[0]);
            string author = red[1];
            string songTitle = red[2];
            TimeSpan duration = TimeSpan.Parse(red[3]);

            return new Song(iD, author, songTitle, duration);
        }
        public override string ToString()
        {
            return "Song [id:" + ID + "] " + Author + " " + SongTitle + " " + Duration;
        }


        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ID + "," + Author + "," + SongTitle + "," + Duration);
            return sb.ToString();
        }

        public static void ShowAllSongs()
        {
            for (int i = 0; i < ListSongs.Count; i++)
            {
                Console.WriteLine(ListSongs[i]);
            }
        }
        public static void SongsFromFile(string nazivDatoteke)
        {
            if (System.IO.File.Exists(nazivDatoteke))
            {
                StreamReader reader1 = System.IO.File.OpenText(nazivDatoteke);

                string linija = ",";
                while ((linija = reader1.ReadLine()) != null)
                {
                    ListSongs.Add(Song.FromFileToObject(linija));
                }
                reader1.Close();
            }
            else
            {
                Console.WriteLine("The file does not exist or the path is incorrect.");


            }

        }

        public static void AddSong()
        {
            int iD = ListSongs.Count() + 1;

            Console.WriteLine("Author:");
            string author = Console.ReadLine();

            Console.WriteLine("Song Title:");
            string songTitle = Console.ReadLine();


            string input = " ";
            string format = "hh\\:mm\\:ss";
            Console.WriteLine("Song duration :" + input);
            input = Console.ReadLine();
            bool validDuration = TimeSpan.TryParseExact(input, format, CultureInfo.CurrentCulture, out TimeSpan duration);

            Console.WriteLine(input, duration);

            Song song = new Song(iD, author, songTitle, duration);
            ListSongs.Add(song);
        }

        public static void SaveSongToFile(string nazivDatoteke)
        {
            if (System.IO.File.Exists(nazivDatoteke))
            {
                StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.UTF8);

                foreach (Song s in ListSongs)
                {
                    writer.WriteLine(s.ToFileString());
                }
                writer.Close();


            }
            else
            {
                Console.WriteLine("The file does not exist or the path is incorrect.");
            }

        }
        public static Song FindSong(int id)
        {
            Song retVal = null;
            for (int i = 0; i < ListSongs.Count; i++)
            {
                Song song = ListSongs[i];
                if (song.ID == id)
                {
                    retVal = song;
                    break;
                }
            }
            return retVal;
        }


        public static void PlaySong()
        {
            Console.WriteLine("Enter the number of the song you want to listen to:");
            int id = AuxiliaryClass.ReadInteger();
            Song song = FindSong(id);
            if (song != null)
            {
                Console.WriteLine(DateTime.Now + song.SongTitle);
            }
            else
            {
                Console.WriteLine("Wrong number, enter the correct number");
            }

        }

    }
}


