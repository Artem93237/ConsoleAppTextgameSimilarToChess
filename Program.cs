using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppTextgameSimilarToChess
{
    class Program
    {
        static string[] panState;
        static private void Print(string str)
        {

            return;
        }
        static void Main(string[] args)
        {
            string who = Console.ReadLine();
            if (who != "white" && who != "black")
            {
                Console.WriteLine(who);
                return;
            }
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Input file doesn't exist.");
                return;
            }
            panState = File.ReadAllLines(path);
            path = Console.ReadLine();

        }
    }
}
