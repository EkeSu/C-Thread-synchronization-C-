using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForThreadStaticAttribute
    {
        [ThreadStatic]
        static int x;

        static int y;

        public static void StaticAttributeThread()
        {
            Task.Run(() => { IncreaseInt(); });
            Task.Run(() => { IncreaseInt(); });
        }

        private static void IncreaseInt()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Format("current thread {0}，x={1}, y={2}",Thread.CurrentThread.GetHashCode(),x++,y++));
            }
        }

    }
}
