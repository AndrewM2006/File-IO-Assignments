using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <EventScore> eventScores = new List <EventScore> ();
            List <double> scores = new List <double> ();
            List <string> results = new List <string> ();
            string name, eventName, menuOption;
            int currentIndex = 0;
            foreach (string line in File.ReadLines(@"results.txt", Encoding.UTF8))
            {
                results.Add (line);
            }
            while (currentIndex < results.Count)
            {
                name = results[currentIndex];
                eventName = results[currentIndex + 1];
                scores = results
                    .Skip(currentIndex + 2)
                    .Take(5)
                    .Select(score => double.TryParse(score, out double parsedScore) ? parsedScore : 0.0)
                    .ToList();
                EventScore eventScore = new EventScore(name, eventName, scores);
                eventScores.Add (eventScore);
                currentIndex += 7;
            }
            while (true)
            {
                Console.WriteLine("Press 1 to Print Scores");
                Console.WriteLine("Press 2 to Print Highest Score");
                Console.WriteLine("Press 3 to Print Lowest Score");
                Console.WriteLine("Press Q for Quit");
                menuOption = Console.ReadLine();
                eventScores.Sort();
                if (menuOption == "1")
                {
                    foreach (EventScore eventScore in eventScores)
                    {
                        Console.WriteLine(eventScore);
                    }
                }
                else if (menuOption == "2")
                {
                    Console.WriteLine(eventScores[eventScores.Count()-1]);
                }
                else if (menuOption == "3")
                {
                    Console.WriteLine(eventScores[0]);
                }
                else if (menuOption == "q" || menuOption == "Q")
                {

                }
            }
        }
    }
}
