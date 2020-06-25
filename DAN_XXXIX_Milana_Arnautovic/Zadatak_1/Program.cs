﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        private static readonly string FileSongs = @"../../Music.txt";







        static void Main(string[] args)
        {
            Song.SongsFromFile(FileSongs);
            int option;
            bool repeat = true;

            do
            {
                Console.WriteLine("OPTIONS");
                Console.WriteLine(" 1 - Add song");
                Console.WriteLine(" 2 - Show all songs");
                Console.WriteLine(" 3 - Play song");

                bool e = int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        Song.AddSong();
                        Song.SaveSongToFile(FileSongs);
                        break;
                    case 2:
                        Song.ShowAllSongs();
                        break;

                    case 3:
                        Song.ShowAllSongs();
                        Song.PlaySong();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong option, enter the correct option. \n");
                        break;
                }
                
            }
            while (repeat);
        }
    }
}

