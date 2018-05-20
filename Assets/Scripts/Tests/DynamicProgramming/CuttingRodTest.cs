using NUnit.Framework;

namespace DynamicProgramming
{

	public class CuttingRodTest
	{

		[SetUp]
		public void SetUp()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

        [Test]
        public void GivenIncorrectInput_ValueIs0()
        {
            //to do, negative prices?

            Assert.AreEqual(0, CuttingRod.GetOptimalCutValue(1, null));
            Assert.AreEqual(0, CuttingRod.GetOptimalCutValue(1, new int[] { }));
            Assert.AreEqual(0, CuttingRod.GetOptimalCutValue(-1, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(0, CuttingRod.GetOptimalCutValue(0, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
        }

		[Test]
		public void GivenCorrectInput_ValueIsMaximum()
		{
            Assert.AreEqual(1, CuttingRod.GetOptimalCutValue(1, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(5, CuttingRod.GetOptimalCutValue(2, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(8, CuttingRod.GetOptimalCutValue(3, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(10, CuttingRod.GetOptimalCutValue(4, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(13, CuttingRod.GetOptimalCutValue(5, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(17, CuttingRod.GetOptimalCutValue(6, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(18, CuttingRod.GetOptimalCutValue(7, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(22, CuttingRod.GetOptimalCutValue(8, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(25, CuttingRod.GetOptimalCutValue(9, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
            Assert.AreEqual(30, CuttingRod.GetOptimalCutValue(10, new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }));
        }

    }
}
