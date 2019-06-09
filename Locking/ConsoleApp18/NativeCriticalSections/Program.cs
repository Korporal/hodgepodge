using CriticalSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            SomeObject obj = new SomeObject();

            Thread t1 = new Thread(ThreadProc);
            Thread t2 = new Thread(ThreadProc);

            t1.Start(obj);
            t2.Start(obj);

            t1.Join();
            t2.Join();

        }

        public static void ThreadProc(object instance)
        {
            SomeObject obj = (SomeObject)(instance);

            for (int I=0; I < 10000; I++)
            {
                obj.ChangeMyState();
                Thread.Sleep(1);
            }
        }

    }

    public class SomeObject : ThreadSafeObject
    {
        public int count_1 = 0;
        public int count_2 = 0;
        public int count_3 = 0;

        public void ChangeMyState()
        {
            LockMe();
            count_1++;
            count_2++;
            count_3++;
            UnlockMe();
        }
    }
}
