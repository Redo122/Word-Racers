using System;
using System.IO;

namespace Word_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dirs = Directory.GetFiles(@"\packs");
            string[] packs = { "", "", "", "", "", "", "", "", "", "" };
            string selectedpack;
            int countpoint = 0;
            Random rnd = new Random();
            Console.WriteLine("╔═╗  ╔══╗  ╔═╗╔═════╗╔═════╗╔═════╗   ╔═════╗╔═════╗╔═════╗╔═════╗╔═════╗╔══════╗\n" +
                              "║ ║ ╔╝  ╚╗ ║ ║║ ╔═╗ ║║ ╔═╗ ║╚╗ ╔╗ ║   ║ ╔═╗ ║║ ╔═╗ ║║ ╔═══╝║ ╔═══╝║ ╔═╗ ║║ ╔════╝\n" +
                              "║ ║╔╝ ╔╗ ╚╗║ ║║ ║ ║ ║║ ╚═╝ ║ ║ ║║ ║   ║ ╚═╝ ║║ ║ ║ ║║ ║    ║ ╚══╗ ║ ╚═╝ ║║ ╚════╗\n" +
                              "║ ╚╝ ╔╝╚╗ ╚╝ ║║ ║ ║ ║║ ╔╗ ╔╝ ║ ║║ ║   ║ ╔╗ ╔╝║ ╚═╝ ║║ ║    ║ ╔══╝ ║ ╔╗ ╔╝╚════╗ ║\n" +
                              "╚╗  ╔╝  ╚╗  ╔╝║ ╚═╝ ║║ ║║ ╚╗╔╝ ╚╝ ║   ║ ║║ ╚╗║ ╔═╗ ║║ ╚═══╗║ ╚═══╗║ ║║ ╚╗╔════╝ ║\n" +
                              " ╚══╝    ╚══╝ ╚═════╝╚═╝╚══╝╚═════╝   ╚═╝╚══╝╚═╝ ╚═╝╚═════╝╚═════╝╚═╝╚══╝╚══════╝\n" +
                              "v0.1\n" +
                              "FEATURE TEST BUILD\n" +
                              "Select a word pack:");
            Console.WriteLine(dirs.Length + " packs found:");
            foreach (string dir in dirs)
            {
                packs[countpoint] = dir;
                countpoint = countpoint + 1;
                Console.WriteLine(countpoint + ") " + dir);
            }
            int selected = Convert.ToInt16(Console.ReadLine());
            selectedpack = packs[selected - 1];
            Console.Clear();
            Console.WriteLine(selectedpack);
            string[] words = File.ReadAllLines(selectedpack);
            Console.WriteLine(words.Length);
            int selectedword = rnd.Next(words.Length);
            Console.WriteLine(words[selectedword]);
        }
    }
}