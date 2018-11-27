using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForAutoResetEvent
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static Stopwatch stopwatch = new Stopwatch();

        public static void AutoResetEventThread()
        {
            stopwatch.Start();
            var success = autoResetEvent.WaitOne(1000, true);
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + "获取信号:" + success + ",时间:" + stopwatch.Elapsed);

            success = autoResetEvent.WaitOne(1000);
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + "获取信号:" + success + ",时间:" + stopwatch.Elapsed);
        }

        public static void GetSignalTest()
        {
            autoResetEvent.Set();
            new Thread(new ThreadStart(PrintOneHundred)).Start();
            new Thread(new ThreadStart(PrintTwoHundred)).Start();
        }

        private static void PrintOneHundred()
        {
            autoResetEvent.Reset();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            autoResetEvent.Set();
        }

        private static void PrintTwoHundred()
        {
            var hasSignal = autoResetEvent.WaitOne(1000, false);
            for (int i = 100; i < 200; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
