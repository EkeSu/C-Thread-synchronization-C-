using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForMonitor
    {
        private int number;

        public void MonitorThread()
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
            Console.WriteLine(string.Format("Thread {0} enter Method:",Thread.CurrentThread.Name));
            Monitor.Enter(this);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("Thread {0} increase number value:{1}", Thread.CurrentThread.Name, number++));
            }
            Monitor.Exit(this);
            Console.WriteLine(string.Format("Thread {0} exit Method:", Thread.CurrentThread.Name));
        }
    }
}
