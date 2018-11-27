using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadConsole.DBHelper;
using Dapper;
using System.Runtime.Remoting.Contexts;

namespace ThreadConsole.ThreadTest
{
    [Synchronization]
    class ThreadTestForSynchronization:ContextBoundObject
    {
        static string connectionStr = "Server=127.0.0.1;Port=3306;Stmt=;Database=exe_dev; User=root;Password=123456";
        public void SynchronizationSafeThread()
        {
            Thread ThreadOne = new Thread(new ThreadStart(DrawMoney));
            ThreadOne.Name = "A001";

            Thread ThreadTwo = new Thread(new ThreadStart(DrawMoney));
            ThreadTwo.Name = "A002";

            ThreadOne.Start();
            ThreadTwo.Start();
        }

        private void DoDrawMoney()
        {
            Random random = new Random();
            int money = random.Next(100);

            string userId = Thread.CurrentThread.Name;
            string selectSql = "select balance from user_balance where user_id=@UserId";
            string updateSql = "update user_balance set balance=@Balance+@Money where user_id=@UserId";
            string updateSql2 = "update user_balance set balance=balance-@Money where user_id<>@UserId";
            using (MySqlConnection conn = MySqlConnectionHelper.OpenConnection(connectionStr))
            {
                var balance = conn.ExecuteScalar(selectSql, new { UserId = userId });
                if (balance != null)
                {
                    conn.Execute(updateSql, new { Money = money, Balance = balance, UserId = userId });
                    conn.Execute(updateSql2, new { Money = money, Balance = balance, UserId = userId });
                }
            }
        }

        private void DrawMoney()
        {
            for (int i = 0; i < 100; i++)
            {
                DoDrawMoney();
            }
            Console.WriteLine("Thread "+Thread.CurrentThread.Name +" is done!");
        }

    }
}
