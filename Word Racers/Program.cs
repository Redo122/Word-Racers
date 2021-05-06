using System;
using System.IO;

namespace Word_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dirs = Directory.GetFiles(@"\Packs");
            string[] packs = { "", "", "", "", "", "", "", "", "", "" };
            string[] car1 = { "    ______                                 F", "       ______                              F", "          ______                           F", "             ______                        F", "                ______                     F", "                   ______                  F", "                      ______               F", "                         ______            F", "                            ______         F", "                               ______      F", "                                  ______   F" };
            string[] car2 = { "  _[|_|__|]__                              I", "     _[|_|__|]__                           I", "        _[|_|__|]__                        I", "           _[|_|__|]__                     I", "              _[|_|__|]__                  I", "                 _[|_|__|]__               I", "                    _[|_|__|]__            I", "                       _[|_|__|]__         I", "                          _[|_|__|]__      I", "                             _[|_|__|]__   I", "                                _[|_|__|]__I" };
            string[] car3 = { " |  _    _   |                             N", "    |  _    _   |                          N", "       |  _    _   |                       N", "          |  _    _   |                    N", "             |  _    _   |                 N", "                |  _    _   |              N", "                   |  _    _   |           N", "                      |  _    _   |        N", "                         |  _    _   |     N", "                            |  _    _   |  N", "                               |  _    _   |" };
            string[] car4 = { " [_(O)__(O)__] -- -- -- -- -- -- -- -- -- --", " -- [_(O)__(O)__] -- -- -- -- -- -- -- -- --", " -- -- [_(O)__(O)__] -- -- -- -- -- -- -- --", " -- -- -- [_(O)__(O)__] -- -- -- -- -- -- --", " -- -- -- -- [_(O)__(O)__] -- -- -- -- -- --", " -- -- -- -- -- [_(O)__(O)__] -- -- -- -- --", " -- -- -- -- -- -- [_(O)__(O)__] -- -- -- --", " -- -- -- -- -- -- -- [_(O)__(O)__] -- -- --", " -- -- -- -- -- -- -- -- [_(O)__(O)__] -- --", " -- -- -- -- -- -- -- -- -- [_(O)__(O)__] --", " -- -- -- -- -- -- -- -- -- -- [_(O)__(O)__]" };
            string selectedpack, input;
            int countpoint = 0, score = 0, errors = 0;
            Random rnd = new Random();
            Console.WriteLine("╔═╗  ╔══╗  ╔═╗╔═════╗╔═════╗╔═════╗   ╔═════╗╔═════╗╔═════╗╔═════╗╔═════╗╔══════╗\n" +
                              "║ ║ ╔╝  ╚╗ ║ ║║ ╔═╗ ║║ ╔═╗ ║╚╗ ╔╗ ║   ║ ╔═╗ ║║ ╔═╗ ║║ ╔═══╝║ ╔═══╝║ ╔═╗ ║║ ╔════╝\n" +
                              "║ ║╔╝ ╔╗ ╚╗║ ║║ ║ ║ ║║ ╚═╝ ║ ║ ║║ ║   ║ ╚═╝ ║║ ║ ║ ║║ ║    ║ ╚══╗ ║ ╚═╝ ║║ ╚════╗\n" +
                              "║ ╚╝ ╔╝╚╗ ╚╝ ║║ ║ ║ ║║ ╔╗ ╔╝ ║ ║║ ║   ║ ╔╗ ╔╝║ ╚═╝ ║║ ║    ║ ╔══╝ ║ ╔╗ ╔╝╚════╗ ║\n" +
                              "╚╗  ╔╝  ╚╗  ╔╝║ ╚═╝ ║║ ║║ ╚╗╔╝ ╚╝ ║   ║ ║║ ╚╗║ ╔═╗ ║║ ╚═══╗║ ╚═══╗║ ║║ ╚╗╔════╝ ║\n" +
                              " ╚══╝    ╚══╝ ╚═════╝╚═╝╚══╝╚═════╝   ╚═╝╚══╝╚═╝ ╚═╝╚═════╝╚═════╝╚═╝╚══╝╚══════╝\n" +
                              "v1\n" +
                              "DEVELOPMENT BUILD\n" +
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
            string[] words = File.ReadAllLines(selectedpack);
            while (score < 11)
            {
                Console.Clear();
                int selectedword = rnd.Next(words.Length);
                Console.WriteLine(words[selectedword] + Environment.NewLine + car1[score] + Environment.NewLine + car2[score] + Environment.NewLine + car3[score] + Environment.NewLine + car4[score]);
                Console.Write(Environment.NewLine + "                                            " + score + "/10\n");
                if (score == 10)
                {
                    Console.WriteLine("You Win with " + errors + " mistakes!\nPress any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                input = Console.ReadLine();
                errors = errors + 1;
                if (words[selectedword] == input.ToUpper())
                {
                    score = score + 1;
                    errors = errors - 1;
                }
            }
        }
    }
}