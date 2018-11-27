using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForAbort
    {
        public static void AbortThread()
        {
            Thread newThread = new Thread(new ThreadStart(PrintNo));
            newThread.Name = "new thread for abort";
            newThread.Start();
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
                        Thread.CurrentThread.Abort(); // 中断当前线程，会引发异常
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("current thread is " + Thread.CurrentThread.Name + ", state: " + Thread.CurrentThread.ThreadState);

                        Console.WriteLine("new thread Aborted" + ex.Message);

                        // 取消当前线程请求的Abort();
                        //Thread.ResetAbort();
                    }
                    Console.WriteLine("current thread is " + Thread.CurrentThread.Name + ", state: " + Thread.CurrentThread.ThreadState);

                }
            }
        }

    }
}
