using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForMonitorTryEnter
    {
        private int number;

        public void MonitorTryEnterThread()
        {
            Thread ThreadOne = new Thread(new ThreadStart(PrintNumber));
            ThreadOne.Name = "梁山伯";

            Thread ThreadTwo = new Thread(new ThreadStart(PrintNumber));
            ThreadTwo.Name = "祝英台";

            ThreadOne.Start();
            ThreadTwo.Start();
        }

        private void PrintNumber()
        {
            Console.WriteLine(string.Format("Thread {0} enter Method:", Thread.CurrentThread.Name));
            bool isLock = Monitor.TryEnter(this,1000);
            Console.WriteLine(string.Format("Thread {0} Get Lock {1}", Thread.CurrentThread.Name, isLock));
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(string.Format("Thread {0} increase number value:{1}", Thread.CurrentThread.Name, number++));
            }

            if (isLock)
            {
                Monitor.Exit(this);
            }

            Console.WriteLine(string.Format("Thread {0} exit Method:", Thread.CurrentThread.Name));
        }
    }
}
