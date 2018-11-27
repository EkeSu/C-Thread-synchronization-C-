using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForMutex
    {
        static Mutex myMutex;
        public static void MutexThread()
        {
            myMutex = new Mutex(true, "myMutex");
            new Thread(new ThreadStart(PrintNo)).Start();

            for (int i = 6; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            myMutex.ReleaseMutex();
        }

        private static void PrintNo()
        {
            myMutex.WaitOne();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
