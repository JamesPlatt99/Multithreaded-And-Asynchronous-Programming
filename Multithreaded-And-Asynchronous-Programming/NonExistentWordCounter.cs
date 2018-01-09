using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Multithreaded_And_Asynchronous_Programming
{
    class NonExistentWordCounter
    {
        private ConcurrentQueue<string> articleWords = new ConcurrentQueue<string>();
        private HashSet<string> validWords = new HashSet<string>();
        private string article;
        private string words;


        private void ReadArticle()
        {
            article = new WebClient().DownloadStringTaskAsync(
              @"https://msdn.microsoft.com/en-gb/library/mt674882.aspx").Result;
        }

        private void ReadWords()
        {
            words = new WebClient().DownloadStringTaskAsync(
              @"https://raw.githubusercontent.com/dwyl/english-words/master/words.txt").Result;
        }

        public async Task<int> CountNonExistentWordsAsync()
        {
            var thread1 = new Thread(ReadArticle);
            var thread2 = new Thread(ReadWords);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            HashSet<string> wordList = new HashSet<string>(words.Split('\n'));

            int nonExistentWords = article.Split('\n', ' ').Count(n => !wordList.Contains(n));

            return nonExistentWords;
        }
    }
}
