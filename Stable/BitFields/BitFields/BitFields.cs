using System;
using System.Text;

namespace Steadsoft.BitFields
{
    public struct Bit8
    {
        private const Byte BIT1 = 1;
        private const Byte BIT0 = 0;

        private const SByte MAX_BIT_NUMBER = 7;

        private Byte value;

        public Bit8(Byte Value)
        {
            value = Value;
        }

        public bool this[Byte BitNumber]
        {
            get
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                Byte mask = (Byte)(BIT1 << BitNumber);
                return (mask & value) != 0;
            }
            set
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                Byte mask = (Byte)(BIT1 << BitNumber);
                this.value = value ? (Byte)(mask | this.value) : (Byte)(mask ^ this.value);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            for (SByte X = MAX_BIT_NUMBER; X >= 0; X--)
                text.Append(this[(Byte)X] ? '1' : '0');

            return text.ToString();
        }

        public Byte BitsOn
        {
            get
            {
                if (value == Byte.MinValue)
                    return 0;

                if (value == Byte.MaxValue)
                    return (Byte)MAX_BIT_NUMBER+1;

                return BitCount(true);
            }
        }

        public Byte BitsOff
        {
            get
            {
                return (byte)((MAX_BIT_NUMBER + 1) - BitsOn);
            }
        }

        private Byte BitCount(bool State)
        {
            Byte count = 0;
            for (SByte X = MAX_BIT_NUMBER; X >= 0; X--)
                if (this[(Byte)X] == State)
                    count++;
            return count;
        }

        public void SetAll(bool State)
        {
            if (State)
                value = Byte.MaxValue;
            else
                value = 0;
        }
    }
    public struct Bit16
    {
        private const UInt16 BIT1 = 1;
        private const SByte MAX_BIT_NUMBER = 15;

        private UInt16 value;

        public Bit16(UInt16 Value)
        {
            value = Value;
        }

        public bool this[Byte BitNumber]
        {
            get
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt16 mask = (UInt16)(BIT1 << BitNumber);
                return (mask & value) != 0;
            }
            set
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt16 mask = (UInt16)(BIT1 << BitNumber);
                this.value = value ? (UInt16)(mask | this.value) : (UInt16)(mask ^ this.value);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            for (SByte X = MAX_BIT_NUMBER; X >= 0; X--)
                text.Append(this[(Byte)X] ? '1' : '0');

            return text.ToString();
        }

        public Byte BitsOn
        {
            get
            {
                if (value == UInt16.MinValue)
                    return 0;

                if (value == UInt16.MaxValue)
                    return (Byte)MAX_BIT_NUMBER+1;

                return BitCount(true);
            }
        }

        public Byte BitsOff
        {
            get
            {
                return (byte)((MAX_BIT_NUMBER + 1) - BitsOn);
            }
        }

        private Byte BitCount(bool State)
        {
            Byte count = 0;
            for (SByte X = MAX_BIT_NUMBER; X >= 0; X--)
                if (this[(Byte)X] == State)
                    count++;
            return count;
        }

        public Bit8 GetByte(Byte ByteNumber)
        {
            if (ByteNumber > 1) throw new ArgumentOutOfRangeException(nameof(ByteNumber));

            Bit8 result = new Bit8((Byte)((value & Constants.ByteAccessor16[ByteNumber]) >> Constants.ByteShifter16[ByteNumber]));

            return result;
        }

        public void SetAll(bool State)
        {
            if (State)
                value = UInt16.MaxValue;
            else
                value = 0;
        }


    }
    public struct Bit32
    {
        private const UInt32 BIT1 = 1;
        private const Byte MAX_BIT_NUMBER = 31;

        private UInt32 value;

        public Bit32(UInt32 Value)
        {
            value = Value;
        }

        public bool this[Byte BitNumber]
        {
            get
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt32 mask = (UInt32)(BIT1 << BitNumber);
                return (mask & value) != 0;
            }
            set
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt32 mask = (UInt32)(BIT1 << BitNumber);
                this.value = value ? (UInt32)(mask | this.value) : (UInt32)(mask ^ this.value);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            for (Byte X = MAX_BIT_NUMBER; X >= 0; X--)
                text.Append(this[(Byte)X] ? '1' : '0');

            return text.ToString();
        }

        public Byte BitsOn
        {
            get
            {
                if (value == UInt32.MinValue)
                    return 0;

                if (value == UInt32.MaxValue)
                    return (Byte)MAX_BIT_NUMBER+1;

                return BitCount(true);
            }
        }

        public Byte BitsOff
        {
            get
            {
                return (byte)((MAX_BIT_NUMBER + 1) - BitsOn);
            }
        }

        private Byte BitCount(bool State)
        {
            Byte count = 0;
            for (Byte X = MAX_BIT_NUMBER; X >= 0; X--)
                if (this[(Byte)X] == State)
                    count++;
            return count;
        }

        public void SetAll(bool State)
        {
            if (State)
                value = UInt32.MaxValue;
            else
                value = 0;
        }

        public Bit8 GetByte(Byte ByteNumber)
        {
            if (ByteNumber > 3) throw new ArgumentOutOfRangeException(nameof(ByteNumber));

            Bit8 result = new Bit8((Byte)((value & Constants.ByteAccessor32[ByteNumber]) >> Constants.ByteShifter32[ByteNumber]));

            return result;
        }
    }
    public struct Bit64
    {
        private const UInt64 BIT1 = 1;
        private const Byte MAX_BIT_NUMBER = 63;

        private UInt64 value;

        public Bit64(UInt64 Value)
        {
            value = Value;
        }

        public bool this[Byte BitNumber]
        {
            get
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt64 mask = (UInt64)(BIT1 << BitNumber);
                return (mask & value) != 0;
            }
            set
            {
                if (BitNumber > MAX_BIT_NUMBER) throw new ArgumentOutOfRangeException(nameof(BitNumber));

                UInt64 mask = (UInt64)(BIT1 << BitNumber);
                this.value = value ? (UInt64)(mask | this.value) : (UInt64)(mask ^ this.value);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            for (Byte X = MAX_BIT_NUMBER; X >= 0; X--)
                text.Append(this[(Byte)X] ? '1' : '0');

            return text.ToString();
        }

        public Bit8 GetByte(Byte ByteNumber)
        {
            if (ByteNumber > 7) throw new ArgumentOutOfRangeException(nameof(ByteNumber));

            Bit8 result = new Bit8((Byte)((value & Constants.ByteAccessor64[ByteNumber]) >> Constants.ByteShifter64[ByteNumber]));

            return result;
        }

        public Byte BitsOn
        {
            get
            {
                if (value == 0)
                    return 0;

                if (value == UInt64.MaxValue)
                    return (Byte)MAX_BIT_NUMBER+1;

                return BitCount(true);
            }
        }

        public Byte BitsOff
        {
            get
            {
                return (byte)((MAX_BIT_NUMBER + 1) - BitsOn);
            }
        }

        private Byte BitCount(bool State)
        {
            Byte count = 0;
            for (Byte X = MAX_BIT_NUMBER; X >= 0; X--)
                if (this[(Byte)X] == State)
                    count++;
            return count;
        }

        public void SetAll(bool State)
        {
            if (State)
                value = UInt64.MaxValue;
            else
                value = 0;
        }


    }

    internal static class Constants
    {
        internal static UInt16[] ByteAccessor16 =
        {
            0x00FF,
            0xFF00,
        };

        internal static Byte[] ByteShifter16 =
        {
            0 * 8,
            1 * 8,
        };

        internal static UInt32[] ByteAccessor32 =
        {
            0x000000FF,
            0x0000FF00,
            0x00FF0000,
            0xFF000000,
        };

        internal static Byte[] ByteShifter32 =
        {
            0 * 8,
            1 * 8,
            2 * 8,
            3 * 8,
        };

        internal static UInt64[] ByteAccessor64 =
        {
            0x00000000000000FF,
            0x000000000000FF00,
            0x0000000000FF0000,
            0x00000000FF000000,
            0x000000FF00000000,
            0x0000FF0000000000,
            0x00FF000000000000,
            0xFF00000000000000
        };

        internal static Byte[] ByteShifter64 =
        {
            0 * 8,
            1 * 8,
            2 * 8,
            3 * 8,
            4 * 8,
            5 * 8,
            6 * 8,
            7 * 8,
        };
    }
}