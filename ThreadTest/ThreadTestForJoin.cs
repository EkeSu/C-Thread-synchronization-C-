using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForJoin
    {
        static Thread newThread;
        static Thread newThread2;
        static Thread newThread3;
        public static void JoinThread()
        {
            newThread = new Thread(new ThreadStart(PrintNo));
            newThread.Name = "new thread for join";
            newThread.Start();
            newThread2 = new Thread(new ThreadStart(PrintNo2));
            newThread2.Name = "new thread be joined";
            newThread2.Start();
            newThread3 = new Thread(new ThreadStart(PrintThreadThree));
            newThread3.Name = "我是勤劳的小画家";
            newThread3.Start();
        }

        static void PrintNo()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("print " + i);
            }
        }

        static void PrintNo2()
        {
            newThread.Join();
            for (int i = 100; i < 199; i++)
            {
                Console.WriteLine("print " + i);
            }
        }

        static void PrintThreadThree()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("print " + Thread.CurrentThread.Name);
            }
        }
    }
}
