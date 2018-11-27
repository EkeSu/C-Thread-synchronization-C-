using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    public class ThreadTestForManualResetEvent
    {
        static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        static Stopwatch stopwatch = new Stopwatch();

        public static void ManualResetEventThread()
        {
            stopwatch.Start();
            var success = manualResetEvent.WaitOne(1000, false);
            Console.WriteLine(Thread.CurrentThread.GetHashCode()+"获取信号:" + success + ",时间:"+ stopwatch.Elapsed);

            manualResetEvent.Set();

            success = manualResetEvent.WaitOne(1000, false);
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + "获取信号:" + success + ",时间:" + stopwatch.Elapsed);
        }

        public static void GetSignalTest()
        {
            manualResetEvent.Set();
            new Thread(new ThreadStart(PrintOneHundred)).Start();
            new Thread(new ThreadStart(PrintTwoHundred)).Start();
        }

        private static void PrintOneHundred()
        {
            manualResetEvent.Reset();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            manualResetEvent.Set();
        }

        private static void PrintTwoHundred()
        {
            var hasSignal = manualResetEvent.WaitOne(1000, false);
            for (int i = 100; i < 200; i++)
            {
                Console.WriteLine(i);
            }
        }

        static ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
        static ManualResetEvent manualResetEvent2 = new ManualResetEvent(false);
        static ManualResetEvent manualResetEvent3 = new ManualResetEvent(false);
        public static void WaitAllTest()
        {
            new Thread(new ThreadStart(PrintOne)).Start();
            new Thread(new ThreadStart(PrintTwo)).Start();
            new Thread(new ThreadStart(PrintThree)).Start();
            var isOk = ManualResetEvent.WaitAll(new WaitHandle[] { manualResetEvent1, manualResetEvent2, manualResetEvent3 }, 5000, false);
            if (isOk){
                Console.WriteLine("Oh,My God "+isOk);
            }
        }

        public static void WaitAnyTest()
        {
            new Thread(new ThreadStart(PrintOne)).Start();
            new Thread(new ThreadStart(PrintTwo)).Start();
            new Thread(new ThreadStart(PrintThree)).Start();
            var hasSignalIndex = ManualResetEvent.WaitAny(new WaitHandle[] { manualResetEvent1, manualResetEvent2, manualResetEvent3 }, 2000, false);
            if (hasSignalIndex == System.Threading.WaitHandle.WaitTimeout)
            {
                Console.WriteLine("Oh, fail");
            }
            else
            {
                Console.WriteLine("Oh,My God " + hasSignalIndex);
            }
        }

        private static void PrintOne()
        {
            manualResetEvent1.Set();
        }
        private static void PrintTwo()
        {
            manualResetEvent2.Set();
        }
        private static void PrintThree()
        {
            manualResetEvent3.Set();
        }
    }
}
