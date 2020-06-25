using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Advertising
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        static readonly string FileAdvertising = @"../../Advertising.txt";
        static Random random = new Random();
        public static int dur;

        public Advertising(int id, string name)
        {
            Id = id;
            Name = name;
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
    }
}
