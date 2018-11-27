using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadConsole.DBHelper;
using Dapper;
using System.Runtime.CompilerServices;

namespace ThreadConsole.ThreadTest
{
    class ThreadTestForUnSafe
    {
        static string connectionStr = "Server=127.0.0.1;Port=3306;Stmt=;Database=exe_dev; User=root;Password=123456";
        public static void UnSafeThread() {
            Thread ThreadOne = new Thread(new ThreadStart(DrawMoney));
            ThreadOne.Name = "A001";

            Thread ThreadTwo = new Thread(new ThreadStart(DrawMoney));
            ThreadTwo.Name = "A002";

            ThreadOne.Start();
            ThreadTwo.Start();
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        private static void DoDrawMoney()
        {
            Random random = new Random();
            int money = random.Next(100);

            string userId = Thread.CurrentThread.Name;
            string selectSql = "select balance from user_balance where user_id=@UserId";
            string updateSql = "update user_balance set balance=@Balance+@Money where user_id=@UserId";
            string updateSql2 = "update user_balance set balance=balance-@Money where user_id<>@UserId";
            using (MySqlConnection conn= MySqlConnectionHelper.OpenConnection(connectionStr))
            {
                var balance = conn.ExecuteScalar(selectSql, new { UserId = userId });
                if (balance != null)
                {
                    conn.Execute(updateSql, new { Money = money, Balance=balance, UserId = userId });
                    conn.Execute(updateSql2, new { Money = money, Balance = balance, UserId = userId });
                }
            }
        }

        private static void DrawMoney() {
            for (int i = 0; i < 100; i++)
            {
                DoDrawMoney();
            }

            Console.WriteLine("Thread " + Thread.CurrentThread.Name + " is done!");
        }



    }
}












//string sumMonney = "select sum(balance) from user_balance";

//int count = 0;
//            while (count< 200)
//            {
//                using (MySqlConnection conn = MySqlConnectionHelper.OpenConnection(connectionStr))
//                {
//                    var balance = conn.ExecuteScalar(sumMonney);
//Console.WriteLine("sum money:" + balance);
//                }

//                count++;
//            }