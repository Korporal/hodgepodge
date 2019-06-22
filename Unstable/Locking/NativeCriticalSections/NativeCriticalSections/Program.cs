using CriticalSections;
using System;
using System.Diagnostics;
using System.Threading;

namespace NativeCriticalSections
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Stopwatch clock = new Stopwatch();
            // Create two threads to manipulate the object.
            Thread t1 = new Thread(ThreadProcSpin);
            Thread t2 = new Thread(ThreadProcSpin);

            // create an object that will be concurrently manipulated by several threads.
            SomeObjectSpin obj = new SomeObjectSpin();

            clock.Start();

            // Start them
            t1.Start(obj);
            t2.Start(obj);

            // Wait for each thread to complete.
            t1.Join();
            t2.Join();

            // Stop the clock.
            clock.Stop();

        } // put a breakpoint here and examine 'obj'

        public static void ThreadProcSpin(object instance)
        {
            SomeObjectSpin obj = (SomeObjectSpin)(instance);

            for (int I=0; I < 1000000000; I++)
            {
                obj.ChangeMyState();
            }
        }

        public static void ThreadProcDotNet(object instance)
        {
            SomeObjectDotNet obj = (SomeObjectDotNet)(instance);

            for (int I = 0; I < 1000000000; I++)
            {
                obj.ChangeMyState();
            }
        }

    }

    public class SomeObjectDotNet 
    {
        public int count_1 = 0;
        public int count_2 = 0;
        public int count_3 = 0;

        public void ChangeMyState()
        {
            lock(this) // fine for benchamarking
            {
                count_1++;
                count_2++;
                count_3++;
            }
        }
    }


    public class SomeObjectSpin : SpinLockedObject
    {

        public int count_1 = 0;
        public int count_2 = 0;
        public int count_3 = 0;

        public void ChangeMyState()
        {
            LockMe();
            {
                count_1++;
                count_2++;
                count_3++;
            }
            UnlockMe();
        }
    }
}