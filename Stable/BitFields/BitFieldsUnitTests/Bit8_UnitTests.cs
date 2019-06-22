using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steadsoft.BitFields;

namespace BitFieldsUnitTests
{
    [TestClass]
    public class Bit8_UnitTests
    {
        [TestMethod]
        public void TestBit8_Create_1()
        {
            Bit8 bit8 = new Bit8();
            Assert.IsTrue(bit8.BitsOn == 0);
        }

        [TestMethod]
        public void TestBit8_Create_2()
        {
            Bit8 bit8 = new Bit8(0);
            Assert.IsTrue(bit8.BitsOn == 0);
        }

        [TestMethod]
        public void TestBit8_Create_3()
        {
            Bit8 bit8 = new Bit8(0B_1111_1111);
            Assert.IsTrue(bit8.BitsOn == 8);
        }

        [TestMethod]
        public void TestBit8_Create_4()
        {
            Bit8 bit8 = new Bit8(0B_0000_1111);
            Assert.IsTrue(bit8.BitsOn == 4);
        }

        [TestMethod]
        public void TestBit8_Create_5()
        {
            Bit8 bit8 = new Bit8(0B_1111_0000);
            Assert.IsTrue(bit8.BitsOn == 4);
        }

        public void TestBit8_Create_6()
        {
            Bit8 bit8 = new Bit8(0B_1010_1010);
            Assert.IsTrue(bit8.BitsOn == 4);
        }

        public void TestBit8_Create_7()
        {
            Bit8 bit8 = new Bit8(0B_0101_0101);
            Assert.IsTrue(bit8.BitsOn == 4);
        }

        public void TestBit8_SetBits_1()
        {
            Bit8 bit8 = new Bit8();

            bit8[0] = true;
            Assert.IsTrue(bit8.BitsOn == 1);
            bit8[1] = true;
            Assert.IsTrue(bit8.BitsOn == 2);
            bit8[2] = true;
            Assert.IsTrue(bit8.BitsOn == 3);
            bit8[3] = true;
            Assert.IsTrue(bit8.BitsOn == 4);
            bit8[4] = true;
            Assert.IsTrue(bit8.BitsOn == 5);
            bit8[5] = true;
            Assert.IsTrue(bit8.BitsOn == 6);
            bit8[6] = true;
            Assert.IsTrue(bit8.BitsOn == 7);
            bit8[7] = true;
            Assert.IsTrue(bit8.BitsOn == 8);
        }

        public void TestBit8_UnsetBits_1()
        {
            Bit8 bit8 = new Bit8(0B_1111_1111);

            bit8[0] = false;
            Assert.IsTrue(bit8.BitsOn == 7);
            bit8[1] = false;
            Assert.IsTrue(bit8.BitsOn == 6);
            bit8[2] = false;
            Assert.IsTrue(bit8.BitsOn == 5);
            bit8[3] = false;
            Assert.IsTrue(bit8.BitsOn == 4);
            bit8[4] = false;
            Assert.IsTrue(bit8.BitsOn == 3);
            bit8[5] = false;
            Assert.IsTrue(bit8.BitsOn == 2);
            bit8[6] = false;
            Assert.IsTrue(bit8.BitsOn == 1);
            bit8[7] = false;
            Assert.IsTrue(bit8.BitsOn == 0);
        }

        public void TestBit8_SetBits_2()
        {
            Bit8 bit8 = new Bit8();

            bit8.SetAll(true);

            Assert.IsTrue(bit8.BitsOn == 8);
        }

        public void TestBit8_UnsetBits_2()
        {
            Bit8 bit8 = new Bit8(0B_1111_1111);

            bit8.SetAll(false);

            Assert.IsTrue(bit8.BitOff == 8);
        }
    }
}