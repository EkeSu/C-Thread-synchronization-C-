using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForInterLock
    {
        private static int a = 0;
        public static void InterLockThread()
        {
            for (int i = 0; i < 100; i++)
            {
                new Thread(new ThreadStart(IncreaseInt)).Start();
            }

            for (int i = 0; i < 100; i++)
            {
                new Thread(new ThreadStart(IncreaseInt)).Start();
            }
        }

        private static void IncreaseInt()
        {
            for (int i = 0; i < 1000; i++)
            {
                //a++;
                Interlocked.Increment(ref a);
            }
            Console.WriteLine(string.Format("Thread：{0}  value: {1}", Thread.CurrentThread.GetHashCode(), a));
        }
    }

    //private static int _result;
    //Main方法
    //public static void InterLockThread()
    //{
    //    运行后按住Enter键数秒，对比使用Interlocked.Increment(ref _result);与 _result++;的不同
    //    while (true)
    //    {
    //        Task[] _tasks = new Task[100];
    //        int i = 0;
    //        for (i = 0; i < _tasks.Length; i++)
    //        {
    //            _tasks[i] = Task.Factory.StartNew((num) =>
    //            {
    //                var taskid = (int)num;
    //                Work(taskid);
    //            }, i);
    //        }
    //        Task.WaitAll(_tasks);
    //        Console.WriteLine(_result);
    //        Console.ReadKey();
    //    }
    //}
    //线程调用方法
    //private static void Work(int TaskID)
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        _result++;
    //        Interlocked.Increment(ref _result);
    //    }
    //}

}
