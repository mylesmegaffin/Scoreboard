﻿using System;
using System.IO;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Scoreboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaveScore();
            ReadScoreboard();
        }

        public static void SaveScore()
        {

            while (true)
            {
                //Getting input from the user
                Console.WriteLine("What is your Username (3 Letters):");
                string username = Console.ReadLine();
                if (!username.Contains(":"))
                {
                    if(username.Length <= 3)
                    {
                        Console.WriteLine("What is your High Score:");
                        string highscore = Console.ReadLine();

                        if (Int32.TryParse(highscore, out int numHighScore))
                        {
                            using (StreamWriter file = new StreamWriter(@"C:\Users\myles\source\repos\Scoreboard\Scoreboard\Scoreboard.txt", true))
                            {
                                file.WriteLine(username + ":" + highscore);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("High Score is not a number, Please Enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username Can NOT Be Longer than 3 Letters");
                    }
                }
                else
                {
                    Console.WriteLine("Username Cannot Contain ':', Please Enter a correct username");
                }
            }
        }

        // To make it on the scoreboard you have to have a top 3 score
        public static void ReadScoreboard()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\myles\source\repos\Scoreboard\Scoreboard\Scoreboard.txt");
            string[] split = new string[] { };

            string HSName = "";
            string SName2 = "";
            string SName3 = "";
            int highestScore = 0;
            int Score2 = 0;
            int Score3 = 0;
            foreach (string line in lines)
            {
                // Putting the values into an array; Values[0] are before the ':' (These are strings), Values[1] are after it (These are numbers)
                split = line.Split(":"); ;
                for (int i = 0; i < split.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        // Checking if the Score Top 3
                        Int32.TryParse(split[i], out int tryNum);
                        //Highest Score
                        if (tryNum > highestScore)
                        {
                            Score3 = Score2;
                            SName3 = SName2;
                            Score2 = highestScore;
                            SName2 = HSName;
                            highestScore = tryNum;
                            HSName = split[i - 1];
                        }
                        //2nd Highest Score
                        else if (tryNum > Score2)
                        {
                            Score3 = Score2;
                            SName3 = SName2;
                            Score2 = tryNum;
                            SName2 = split[i - 1];
                        }
                        //3rd Highest Score
                        else if (tryNum > Score3)
                        {
                            Score3 = tryNum;
                            SName3 = split[i - 1];
                        }
                    }
                }
            }
            DisplayBoard(HSName, highestScore, SName2, Score2, SName3, Score3);

            Console.ReadKey();
        }

        public static void DisplayBoard(string HSName, int highestScore, string SName2, int Score2,string SName3, int Score3)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("| Username | Score |");
            Console.WriteLine("--------------------");
            Console.WriteLine("|   {0}    |   {1} |", HSName, highestScore);
            Console.WriteLine("--------------------");
            Console.WriteLine("|   {0}    |   {1} |", SName2, Score2);
            Console.WriteLine("--------------------");
            Console.WriteLine("|   {0}    |   {1} |", SName3, Score3);
            Console.WriteLine("--------------------");


        }

    }
}
