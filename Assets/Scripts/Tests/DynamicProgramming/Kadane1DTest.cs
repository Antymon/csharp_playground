using NUnit.Framework;

namespace DynamicProgramming
{

	public class Kadane1DTest
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
		public void t()
		{
            Assert.AreEqual(6,Kadane1D.GetMaximumSumOfSubarray(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}));
		}

	}
}
