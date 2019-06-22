using System;
using System.Runtime.InteropServices;

namespace CriticalSections
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CRITICAL_SECTION
    {
        public IntPtr DebugInfo;
        public int LockCount;
        public int RecursionCount;
        public IntPtr OwningThread;
        public IntPtr LockSemaphore;
        public IntPtr SpinCount;
    }
}