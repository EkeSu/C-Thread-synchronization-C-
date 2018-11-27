using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadConsole.ThreadTest;

namespace ThreadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 使线程睡眠
            //ThreadTestForSleep.SleepThread();

            // 终止线程
            //ThreadTestForAbort.AbortThread();

            // join线程
            //ThreadTestForJoin.JoinThread();

            // 线程不安全的演示
            //ThreadTestForUnSafe.UnSafeThread();

            // 使用MethodImpl同步线程---同步方法
            //ThreadTestForMethodImpl.MethodImplSafeThread();

            // 使用Synchronization同步线程---同步上下文环境
            //new ThreadTestForSynchronization().SynchronizationSafeThread();

            // 使用Monitor同步重要代码区----同步重要代码区
            //new ThreadTestForMonitor().MonitorThread();

            // 使用Monitor 的Wait和Pulse做线程之间的通信
            //new ThreadTestForMonitorWait().MonitorWaitThread();

            // 使用Monitor TryEnter 尝试获得锁，可设定等待时间；
            //new ThreadTestForMonitorTryEnter().MonitorTryEnterThread();

            // 使用lock锁定代码块
            //new ThreadTestForLock().LockThread();

            // 针对文件的读写锁
            //new ThreadTestForReadWriterLock().ReadWriterLockThread();

            // ManualResetEvent----有两个状态，有信号和无信号，使用WaitOne方法等待信号来延缓线程的执行，也可以继而根据WaitOne的结果判断线程是否要执行。个人理解
            //ThreadTestForManualResetEvent.ManualResetEventThread();
            //ThreadTestForManualResetEvent.GetSignalTest();
            //ThreadTestForManualResetEvent.WaitAllTest();
            //ThreadTestForManualResetEvent.WaitAnyTest();
            //ThreadTestForAutoResetEvent.AutoResetEventThread();
            //ThreadTestForAutoResetEvent.GetSignalTest();

            // Mutex同步线程
            //ThreadTestForMutex.MutexThread();

            // 使用 InterLock 同步线程，值类型的原子操作
            //ThreadTestForInterLock.InterLockThread();

            // 使用ThreadStatic为类的静态变量创建副本，使得每一个线程的变量独立。
            ThreadTestForThreadStaticAttribute.StaticAttributeThread();

            Console.Read();
        }
    }
}
