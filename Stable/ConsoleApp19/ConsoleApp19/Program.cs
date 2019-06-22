using Steadsoft.BitFields;
using System;

namespace Steadsoft
{
    class Program
    {
        static void Main(string[] args)
        {
            //BitArray
            Bit16 bitsa = new Bit16(1);
            Bit16 bitsb = new Bit16(2);
            Bit16 bitsc = new Bit16(3);
            Bit16 bitsd = new Bit16(65535);

            Bit32 bitse = new Bit32(1229812);

            var aa = bitse.GetByte(0);
            var bb = bitse.GetByte(1);
            var cc = bitse.GetByte(2);
            var dd = bitse.GetByte(3);

            Bit8 bitsf = new Bit8(0B_11000011);

            Bit64 bitsg = new Bit64(UInt64.MaxValue-1);

            bitsf[0] = true;
            bitsf[1] = true;
            bitsf[2] = true;
            bitsf[3] = true;
            bitsf[4] = true;
            bitsf[5] = true;
            bitsf[6] = true;
            bitsf[7] = true;

            bitsf[4] = false;

            bitsd[3] = false;


        }

    }

}