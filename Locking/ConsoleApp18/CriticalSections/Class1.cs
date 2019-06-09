using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CriticalSections
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CRITICAL_SECTION
    {
        public IntPtr DebugInfo;
        public int LockCount;
        public int RecursionCount;
        public IntPtr OwningThread;
        public IntPtr LockSemaphore;
        public IntPtr SpinCount;
    }

    public unsafe static class Native
    {
        [DllImport("kernel32")]
        public static extern void InitializeCriticalSection(CRITICAL_SECTION* CriticalSection);

        [DllImport("kernel32")]
        public static extern void EnterCriticalSection(CRITICAL_SECTION* CriticalSection);

        [DllImport("kernel32")]
        public static extern void LeaveCriticalSection(CRITICAL_SECTION* CriticalSection);

    }
}
