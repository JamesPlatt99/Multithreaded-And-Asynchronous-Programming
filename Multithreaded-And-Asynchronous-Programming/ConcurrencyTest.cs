using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreaded_And_Asynchronous_Programming
{
    class ConcurrencyTest
    {
        private class DataStore { public int Value { get; set; } }

        private DataStore store = new DataStore();
        private DataStore store2 = new DataStore();
        private DataStore sum = new DataStore();

        public void Test()
        {
            var thread1 = new Thread(IncrementTheValues);
            var thread2 = new Thread(SumStores);
            thread1.Start();
            thread2.Start();

            thread1.Join(); // Wait for the thread to finish executing
            thread2.Join();

            Console.WriteLine($"Final value: {sum.Value}");
        }

        private void IncrementTheValues()
        {
            lock (store2)
            {
                lock (store)
                {
                    store2.Value++;
                    store.Value++;
                }
            }
        }
        private void SumStores()
        {
            lock (store)
            {
                lock (store2)
                {
                    sum.Value += store.Value;
                }
            }
        }
    }
}
