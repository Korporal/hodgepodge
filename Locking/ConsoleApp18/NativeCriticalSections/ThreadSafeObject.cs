using CriticalSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public abstract unsafe class ThreadSafeObject
    {
        private CRITICAL_SECTION section;

        protected ThreadSafeObject()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.InitializeCriticalSection(section_ptr); }
        }

        protected void LockMe()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.EnterCriticalSection(section_ptr); }
        }

        protected void UnlockMe()
        {
            fixed (CRITICAL_SECTION* section_ptr = &section) { Win32.LeaveCriticalSection(section_ptr); }
        }
    }
}
