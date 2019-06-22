using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CriticalSections
{
    public abstract class SpinLockedObject
    {
        public int spinner = 0;

        protected void LockMe()
        {
            while (Interlocked.CompareExchange(ref spinner, 1, 0) == 1)
            {
                Thread.Sleep(1);
            }
        }

        protected void UnlockMe()
        {
            spinner = 0;
        }
    }
}
