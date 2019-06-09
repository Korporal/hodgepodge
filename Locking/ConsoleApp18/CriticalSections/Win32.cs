using System.Runtime.InteropServices;

namespace CriticalSections
{
    public unsafe static class Win32
    {
        [DllImport("kernel32")]
        public static extern void InitializeCriticalSection(CRITICAL_SECTION* CriticalSection);

        [DllImport("kernel32")]
        public static extern void EnterCriticalSection(CRITICAL_SECTION* CriticalSection);

        [DllImport("kernel32")]
        public static extern void LeaveCriticalSection(CRITICAL_SECTION* CriticalSection);
    }
}