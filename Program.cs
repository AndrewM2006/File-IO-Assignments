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
            StreamWriter writer1 = new StreamWriter("../../sortedNumbers.txt");
            StreamWriter writer2 = new StreamWriter("../../numberSummary.txt");
            List <int> numbers = new List<int>();
            int sum=0, average;
            foreach (string line in File.ReadLines(@"numbers.txt", Encoding.UTF8))
            {
                numbers.Add(Convert.ToInt32(line));
            }
            foreach (int number in numbers)
            {
                sum += number;
            }
            average= sum / numbers.Count;
            numbers.Sort();
            foreach (int number in numbers)
            {
                writer1.WriteLine(number);
            }
            writer1.Close();
            writer2.WriteLine($"The sum of the numbers is {sum} and the average is {average}!");
            writer2.Close();
        }
    }
}
