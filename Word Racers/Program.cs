using System;
using System.IO;
using System.Timers;

namespace Word_Racers
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            string[] dirs = Directory.GetFiles(@"Packs");
            string[] packs = { "", "", "", "", "", "", "", "", "", "" };
            string[] car1 = { "    ______                                 F", "       ______                              F", "          ______                           F", "             ______                        F", "                ______                     F", "                   ______                  F", "                      ______               F", "                         ______            F", "                            ______         F", "                               ______      F", "                                  ______   F" };
            string[] car2 = { "  _[|_|__|]__                              I", "     _[|_|__|]__                           I", "        _[|_|__|]__                        I", "           _[|_|__|]__                     I", "              _[|_|__|]__                  I", "                 _[|_|__|]__               I", "                    _[|_|__|]__            I", "                       _[|_|__|]__         I", "                          _[|_|__|]__      I", "                             _[|_|__|]__   I", "                                _[|_|__|]__I" };
            string[] car3 = { " |  _    _   |                             N", "    |  _    _   |                          N", "       |  _    _   |                       N", "          |  _    _   |                    N", "             |  _    _   |                 N", "                |  _    _   |              N", "                   |  _    _   |           N", "                      |  _    _   |        N", "                         |  _    _   |     N", "                            |  _    _   |  N", "                               |  _    _   |" };
            string[] car4 = { " [_(O)__(O)__] -- -- -- -- -- -- -- -- -- --", " -- [_(O)__(O)__] -- -- -- -- -- -- -- -- --", " -- -- [_(O)__(O)__] -- -- -- -- -- -- -- --", " -- -- -- [_(O)__(O)__] -- -- -- -- -- -- --", " -- -- -- -- [_(O)__(O)__] -- -- -- -- -- --", " -- -- -- -- -- [_(O)__(O)__] -- -- -- -- --", " -- -- -- -- -- -- [_(O)__(O)__] -- -- -- --", " -- -- -- -- -- -- -- [_(O)__(O)__] -- -- --", " -- -- -- -- -- -- -- -- [_(O)__(O)__] -- --", " -- -- -- -- -- -- -- -- -- [_(O)__(O)__] --", " -- -- -- -- -- -- -- -- -- -- [_(O)__(O)__]" };
            string selectedpack, input, pb = @"PB.txt", name;
            string[] pbdata = File.ReadAllLines(pb);
            int countpoint = 0, score = 0, errors = 0, time = 0, pberror = Convert.ToInt32(pbdata[1]), pbtime = Convert.ToInt32(pbdata[0]);
            string pbname = pbdata[3], pbpack = pbdata[2];
            Random rnd = new Random();
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            Console.WriteLine("╔═╗  ╔══╗  ╔═╗╔═════╗╔═════╗╔═════╗   ╔═════╗╔═════╗╔═════╗╔═════╗╔═════╗╔══════╗\n" +
                              "║ ║ ╔╝  ╚╗ ║ ║║ ╔═╗ ║║ ╔═╗ ║╚╗ ╔╗ ║   ║ ╔═╗ ║║ ╔═╗ ║║ ╔═══╝║ ╔═══╝║ ╔═╗ ║║ ╔════╝\n" +
                              "║ ║╔╝ ╔╗ ╚╗║ ║║ ║ ║ ║║ ╚═╝ ║ ║ ║║ ║   ║ ╚═╝ ║║ ║ ║ ║║ ║    ║ ╚══╗ ║ ╚═╝ ║║ ╚════╗\n" +
                              "║ ╚╝ ╔╝╚╗ ╚╝ ║║ ║ ║ ║║ ╔╗ ╔╝ ║ ║║ ║   ║ ╔╗ ╔╝║ ╚═╝ ║║ ║    ║ ╔══╝ ║ ╔╗ ╔╝╚════╗ ║\n" +
                              "╚╗  ╔╝  ╚╗  ╔╝║ ╚═╝ ║║ ║║ ╚╗╔╝ ╚╝ ║   ║ ║║ ╚╗║ ╔═╗ ║║ ╚═══╗║ ╚═══╗║ ║║ ╚╗╔════╝ ║\n" +
                              " ╚══╝    ╚══╝ ╚═════╝╚═╝╚══╝╚═════╝   ╚═╝╚══╝╚═╝ ╚═╝╚═════╝╚═════╝╚═╝╚══╝╚══════╝\n" +
                              "v1\n" +
                              "PB: " + pbname + " with " + pbtime + " seconds and " + pberror + " mistakes, on " + pbpack + ".\n" +
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
            aTimer.Enabled = true;
            while (score < 11)
            {
                Console.Clear();
                int selectedword = rnd.Next(words.Length);
                Console.WriteLine(words[selectedword] + "\n" + car1[score] + "\n" + car2[score] + "\n" + car3[score] + "\n" + car4[score]);
                Console.Write("                                            " + time + " seconds\n                                            " + score + "/10\n");
                if (score == 10)
                {
                    if (errors <= pberror)
                    {
                        if (time < pbtime)
                        {
                            Console.WriteLine("NEW PB!\n" +
                                              "You Win in " + time + " seconds with " + errors + " mistakes!\n" +
                                              "Please enter your name:");
                            name = Console.ReadLine();
                            File.WriteAllText(pb, Convert.ToString(time) + "\n" + Convert.ToString(errors) + "\n" + selectedpack + "\n" + name);
                            Console.WriteLine("Thank you, press any key to exit.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You Win in " + time + " seconds with " + errors + " mistakes!\n" +
                                          "Press any key to exit.");
                    }
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
            void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                time = time + 1;
            }
        }
    }
}