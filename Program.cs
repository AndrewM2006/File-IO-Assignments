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
            string name, eventName, menuOption, contestant="";
            int currentIndex = 0, spaceIndex;
            bool valid;
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
                Console.WriteLine("Press 4 to View an Average Score");
                Console.WriteLine("Press 5 to Remove a Contestant");
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
                else if (menuOption == "4")
                {
                    valid = false;
                    while (!valid)
                    {
                        Console.Write("Input Contestant's Name: ");
                        contestant = Console.ReadLine().Trim();
                        spaceIndex = contestant.IndexOf(" ");
                        contestant = char.ToUpper(contestant[0]) + contestant.Substring(1, spaceIndex-1).ToLower() + " " + char.ToUpper(contestant[spaceIndex + 1]) + contestant.Substring(spaceIndex + 2).ToLower();
                        if (eventScores.Exists(x => x.Name == contestant))
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine(contestant + " was not Found");
                        }
                    }
                    for (int i = 0; i < eventScores.Count; i++)
                    {
                        if (contestant == eventScores[i].Name)
                        {
                            Console.WriteLine(contestant + " scored a " + eventScores[i].GetAverage() + " on average");
                        }
                    }
                }
                else if (menuOption == "5")
                {
                    valid = false;
                    while (!valid)
                    {
                        Console.Write("Input Contestant's Name: ");
                        contestant = Console.ReadLine().Trim();
                        spaceIndex = contestant.IndexOf(" ");
                        contestant = char.ToUpper(contestant[0]) + contestant.Substring(1, spaceIndex - 1).ToLower() + " " + char.ToUpper(contestant[spaceIndex + 1]) + contestant.Substring(spaceIndex + 2).ToLower();
                        if (eventScores.Exists(x => x.Name == contestant))
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine(contestant + " was not Found");
                        }
                    }
                    for (int i = 0; i < eventScores.Count; i++)
                    {
                        if (contestant == eventScores[i].Name)
                        {
                            eventScores.Remove(eventScores[i]);
                        }
                    }
                    Console.WriteLine(contestant + " removed");
                }
                else if (menuOption == "q" || menuOption == "Q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
