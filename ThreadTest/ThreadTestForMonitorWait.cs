using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForMonitorWait
    {
        private int result;

        private LockData lockData;
        public ThreadTestForMonitorWait()
        {
            this.lockData = new LockData();
        }

        public void MonitorWaitThread()
        {
            Thread ThreadOne = new Thread(new ThreadStart(WaitFirstThread));
            ThreadOne.Name = "WaitFirstThread";

            Thread ThreadTwo = new Thread(new ThreadStart(PulseFirstThread));
            ThreadTwo.Name = "PulseFirstThread";

            ThreadOne.Start();
            ThreadTwo.Start();
        }


        private void WaitFirstThread()
        {
            Monitor.Enter(lockData);
            Console.WriteLine(string.Format("Thread {0} enter MonitorWaitThread",Thread.CurrentThread.Name));
            for (int i = 0; i < 5; i++)
            {
                Monitor.Wait(lockData);
                Console.WriteLine(string.Format("Thread {0} increase number value {1}", Thread.CurrentThread.Name, result++));
                Monitor.Pulse(lockData);
            }

            Console.WriteLine(string.Format("Thread {0} exit MonitorWaitThread", Thread.CurrentThread.Name));
            Monitor.Exit(lockData);
        }

        private void PulseFirstThread()
        {
            Monitor.Enter(lockData);
            Console.WriteLine(string.Format("Thread {0} enter MonitorWaitThread", Thread.CurrentThread.Name));
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(lockData);
                Console.WriteLine(string.Format("Thread {0} increase number value {1}", Thread.CurrentThread.Name, result++));
                Monitor.Wait(lockData);
            }

            Console.WriteLine(string.Format("Thread {0} exit MonitorWaitThread", Thread.CurrentThread.Name));
            Monitor.Exit(lockData);
        }
    }

    public class LockData { }

}
