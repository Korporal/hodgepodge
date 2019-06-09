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

            Thread.Sleep(100000);

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

    public abstract unsafe class ThreadSafeObject
    {
        private CRITICAL_SECTION section;

        protected ThreadSafeObject()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Native.InitializeCriticalSection(section_ptr); }
        }

        protected void Lock()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Native.EnterCriticalSection(section_ptr); }
        }

        protected void Unlock()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Native.LeaveCriticalSection(section_ptr); }
        }
    }

    public class SomeObject : ThreadSafeObject
    {
        public int count = 0;

        public void ChangeMyState()
        {
            //Lock();
            count++;
            //Unlock();
        }
    }
}
