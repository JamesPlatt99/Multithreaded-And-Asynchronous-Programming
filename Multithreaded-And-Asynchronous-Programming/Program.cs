using System;

namespace Multithreaded_And_Asynchronous_Programming
{
    class Program
    {
        static void Main()
        {
            var concurrencyTest = new ConcurrencyTest();
            while (true)
            {
                concurrencyTest.Test();
            }
        }
    }
}
