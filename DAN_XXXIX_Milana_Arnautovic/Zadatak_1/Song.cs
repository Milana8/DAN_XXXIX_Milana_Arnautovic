using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Song
    {
        static EventWaitHandle waitHande = new AutoResetEvent(false);
        public int ID { get; set; }
        public string Author { get; set; }
        public string SongTitle { get; set; }
        public  TimeSpan Duration { get; set; }

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
        /// <summary>
        /// Method that creates a class based on a text representation from a file
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Song FromFileToObject(string text)
        {
            string[] red = text.Split(',');

            if (red.Length != 4)
            {
                Console.WriteLine("Error " + text);

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
        /// <summary>
        /// method for displaying all songs
        /// </summary>
        public static void ShowAllSongs()
        {
            for (int i = 0; i < ListSongs.Count; i++)
            {
                Console.WriteLine(ListSongs[i]);
            }
        }
        /// <summary>
        /// Method for loading data
        /// </summary>
        /// <param name="nazivDatoteke"></param>
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
        /// <summary>
        /// ethod for adding a new song
        /// </summary>
        public static void AddSong()
        {
            int iD = ListSongs.Count() + 1;

            Console.WriteLine("Author:");
            string author = AuxiliaryClass.ReadText();

            Console.WriteLine("Song Title:");
            string songTitle = AuxiliaryClass.ReadText();


            string input = " ";
            string format = "hh\\:mm\\:ss";
            Console.WriteLine("Song duration :" + input);
            input = Console.ReadLine();
            bool validDuration = TimeSpan.TryParseExact(input, format, CultureInfo.CurrentCulture, out TimeSpan duration);

            Console.WriteLine(input, duration);

            Song song = new Song(iD, author, songTitle, duration);
            ListSongs.Add(song);
        }
        /// <summary>
        /// Saving data to a file
        /// </summary>
        /// <param name="nazivDatoteke"></param>
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
        /// <summary>
        /// Method for finding table reservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method for play song
        /// </summary>
        public static void PlaySong()
        {
            
            Console.WriteLine("Enter the number of the song you want to listen to:");
            int id = AuxiliaryClass.ReadInteger();
            Song song = FindSong(id);
            int a = song.Duration.Hours * 3600000 + song.Duration.Minutes * 60000 + song.Duration.Seconds * 1000;
            int count = a / 1000;
            if (song != null)
            {
                Console.WriteLine(DateTime.Now + " " + song.SongTitle);

                while (count != 0)
                {

                    Thread.Sleep(1000);
                    Console.WriteLine("The song is still playing");

                    count--;
                }

                Console.WriteLine("The song is over");
            }
            else
            {
                Console.WriteLine("Wrong number, enter the correct number");
            }

        }
       

    }
}


