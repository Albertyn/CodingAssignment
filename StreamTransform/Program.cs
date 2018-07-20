using System;
using System.IO;

namespace StreamTransform
{/*
    Read in a series of numbers from a text-file (the data is given below). 
    For each row in the file, setup a thread to calculate the sum of the values of that vector. 
    Each of the vector sums must then be written to a new file, sorted in ascending order. 
    
    Input files contents: 
    6,12,2,9,17 
    7,3,15,19,4 
    10,5,8,21,13 
 
    Expected output: 
    46 
    48 
    57 
*/
    class Utils
    {
        public void VectorOf(string line, ref int total)
        {
            int value = 0; int acc = 0;
            foreach (string token in line.Split(","))
                if (Int32.TryParse(token, out acc)) value += acc;
            total = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello FileSystem! ... reading testfile.txt");

            Utils utils = new Utils();
            var numberList = File.ReadAllLines("testfile.txt");
            int[] totals = new int[numberList.Length];

            for (int i = 0; i < numberList.Length; i++)
            {
                utils.VectorOf(numberList[i], ref totals[i]);

                // totals[i] = numberList[i].Split(",").Select(x => int.Parse(x)).Sum(); // Using Linq
            }

            Array.Sort(totals);

            // make up target path
            string filePath = $"{Directory.GetCurrentDirectory()}/txt/{DateTime.Now.ToFileTimeUtc()}.txt";

            using (StreamWriter file =
            new StreamWriter(filePath, true))
            {
                foreach (int i in totals)
                {
                    Console.WriteLine(i.ToString());
                    file.WriteLine(i.ToString());
                }
            }

            // Keep the console window open
            Console.WriteLine($"Output written to {filePath}\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
