using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Advertising
    {
        public  int Id { get; set; }
        public  string Name { get; set; }

        public Advertising(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<Advertising> ListAdvertisings { get; set; }

        static Advertising()
        {
            ListAdvertisings = new List<Advertising>();
        }
        /// <summary>
        ///  Method that creates a class based on a text representation from a file
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Advertising FromFileToObject(string text)
        {
            string[] red = text.Split(',');

            if (red.Length != 2)
            {
                Console.WriteLine("Error " + text);

            }

            int id = Int32.Parse(red[0]);
            string name = red[1];
            

            return new Advertising(id, name);
        }
       
        public override string ToString()
        {
            return "Advertising [id:" + Id + "] " + Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Id + "," + Name);
            return sb.ToString();
        }
        /// <summary>
        /// Method for loading data
        /// </summary>
        /// <param name="nazivDatoteke"></param>
        public static void AdvetisingFromFile(string nazivDatoteke)
        {
            if (System.IO.File.Exists(nazivDatoteke))
            {
                StreamReader reader1 = System.IO.File.OpenText(nazivDatoteke);

                string linija = ",";
                while ((linija = reader1.ReadLine()) != null)
                {
                    ListAdvertisings.Add(Advertising.FromFileToObject(linija));
                }
                reader1.Close();
            }
            else
            {
                Console.WriteLine("The file does not exist or the path is incorrect.");


            }

        }
    }
}
