using System;
using System.Threading;

namespace SyncronicedThreadingTwo
{
    //This Code prints 60 stars, then the count og chars, then a tag and the new count of tags and so it goes on
    //This code uses monitor.enter/monito.exit as a lock to avoid deadpool
    class Program
    {
        private static int count = 0;
        static Object _lock = new Object();
        static void Main()
        {
            Thread star = new Thread(PrintStar);
            Thread tag = new Thread(PrintTag);
            
            star.Start();
            tag.Start();
        }

        static void PrintStar()
        {
            while (true)
            { 
                Func('*');
            }
        }

        static void PrintTag()
        {
            while (true)
            {
                Func('#');
            }
        }

        static void Func(char symbol)
        {
            Monitor.Enter(_lock);
            try
            {
                for (int i = 0; i < 60; i++)
                {
                    if (true)
                    {
                        Console.Write(symbol);
                    }
                }
                Thread.Sleep(500);
                Console.Write($"{count += 60}\n");
            }
            finally
            {
                Monitor.Exit(_lock);
            }
            
        }
    }
}