using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text;

namespace Multithreaded_And_Asynchronous_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int val =0;
            while (val != 3)
            {
                PrintMenu();
                input = Console.ReadLine();

                if (!int.TryParse(input, out val)) { continue; }

                switch (val)
                {
                    case 1:
                        DoConcurrencyTest();
                        break;
                    case 2:
                        DoNonExistentWordCounter();
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine(" 1. Concurrency Test");
            Console.WriteLine(" 2. Non existent word count");
            Console.WriteLine(" 3. Exit");
        }

        private static void DoConcurrencyTest()
        {
            var concurrencyTest = new ConcurrencyTest();
            while (true)
            {
                concurrencyTest.Test();
            }
        }

        private static async void DoNonExistentWordCounter()
        {
            var nonExistentWordCounter = new NonExistentWordCounter();
            Task<int> counter = nonExistentWordCounter.CountNonExistentWordsAsync();
            int nonExistentWords = await counter;

            Console.WriteLine(nonExistentWords);
        }
    }
}
