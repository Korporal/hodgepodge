using System.Threading;

namespace ConsoleApp18
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            // create an object that will be concurrently manipulated by several threads.
            SomeObject obj = new SomeObject();

            // Create two threads to manipulate the object.
            Thread t1 = new Thread(ThreadProc);
            Thread t2 = new Thread(ThreadProc);

            // Start them
            t1.Start(obj);
            t2.Start(obj);

            // Wait for each thread to complete.
            t1.Join();
            t2.Join();

        } // put a breakpoint here and examine 'obj'

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
