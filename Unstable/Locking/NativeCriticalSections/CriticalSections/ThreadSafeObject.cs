using CriticalSections;
using System.Threading;

namespace NativeCriticalSections
{
    public abstract unsafe class ThreadSafeObject
    {
        private LockType type;
        private CRITICAL_SECTION section;
        private volatile int spinner;

        protected ThreadSafeObject(LockType Type)
        {
            type = Type;

            if (type == LockType.CriticalSection)
               fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.InitializeCriticalSection(section_ptr); }

            if (type == LockType.SpinAndYield)
                ; // nothing special to do.
        }

        protected void LockMe()
        {
            if (type == LockType.CriticalSection)
                fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.EnterCriticalSection(section_ptr); }
            else
            {
                while (Interlocked.CompareExchange(ref spinner, 1, 0) == 1)
                {
                    Thread.Sleep(1);
                }
            }
        }

        protected void UnlockMe()
        {
            if (type == LockType.CriticalSection)
                fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.LeaveCriticalSection(section_ptr); }
            else
                spinner = 0;
        }
    }

    public enum LockType
    {
        CriticalSection,
        SpinAndYield
    }
}