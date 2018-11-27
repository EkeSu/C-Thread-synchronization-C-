using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForReadWriterLock
    {
        ReaderWriterLock rwl = new ReaderWriterLock();

        public void ReadWriterLockThread()
        {
            Thread ThreadOne = new Thread(new ThreadStart(WriterFileLock));
            ThreadOne.Name = "梁山伯";

            Thread ThreadTwo = new Thread(new ThreadStart(WriterFileLock));
            ThreadTwo.Name = "祝英台";
            ThreadTwo.Start();

            ThreadOne.Start();
        }


        private void ReadFileLock()
        {
            try
            { 
                //rwl.AcquireReaderLock(10);
                using (StreamReader reader = new StreamReader("@ReadWriterLokTest.text"))
                {
                    string lineStr = string.Empty;

                    while (!string.IsNullOrWhiteSpace(lineStr = reader.ReadLine()))
                    {
                        Console.WriteLine(lineStr);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //rwl.ReleaseReaderLock();
            }
        }

        private void WriterFileLock()
        {
            try
            {
                rwl.AcquireWriterLock(100);
                using (StreamWriter writer = new StreamWriter("@ReadWriterLokTest.text"))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        writer.WriteLine(i);
                    }
                }
                Console.WriteLine("File Writer Finish");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }
    }
}
