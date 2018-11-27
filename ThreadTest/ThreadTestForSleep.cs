using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForSleep
    {
        public static void SleepThread()
        {
            Thread newThread = new Thread(new ThreadStart(PrintNo));
            newThread.Name = "new thread";
            newThread.Start();
            while (true)
            {
                if (newThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine("current thread state: " + newThread.ThreadState);
                    newThread.Interrupt();
                    break;
                }
            }
        }

        static void PrintNo()
        {
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine("print " + i);
                if (i == 90)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("new thread interrupted"+ex.Message);
                    }
                    Console.WriteLine("current thread is " + Thread.CurrentThread.Name + ", state: " + Thread.CurrentThread.ThreadState);
                }
            }
        }
    }
}
