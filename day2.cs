using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Program
    {
        static int ScoreFromYou(char Choice, bool winner)
        {
            if (Choice is 'A')
            {
                return winner ? 2 : 3;

            }
            else if (Choice is 'B')
            {
                return winner ? 3: 1;
            }
            else
            {
                return winner ? 1: 2;
            }
        }

        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"c:\\users\kewin\desktop\data.txt");

            int TotalScore = 0;

           /* foreach (var line in lines)
            {
                if (line is "C X" || line is "A Y" || line is "B Z")
                {
                    TotalScore += 6;
                    TotalScore += (int)(line[2]) - 87;

                }
                else if (line is "B X" || line is "C Y" || line is "A Z")
                {
                    TotalScore += (int)(line[2]) - 87;

                }
                else
                {
                    TotalScore += 3;
                    TotalScore += (int)(line[2]) - 87;

                }

            } */
            
            foreach (var line in lines)
            {
                if (line[2] is 'Y')
                {
                    TotalScore += 3;
                    TotalScore += (int)(line[0]) - 64;
                }

                else if( line[2] is 'X')
                {
                    TotalScore += ScoreFromYou(line[0], false);
                    Console.WriteLine(TotalScore + " " + line);
                }

                else
                {
                    TotalScore += 6;
                    TotalScore += ScoreFromYou(line[0], true);
                    Console.WriteLine(TotalScore + " " + line);
                }

            }

            Console.WriteLine(TotalScore);
            Console.ReadLine();
        }

    }
}
