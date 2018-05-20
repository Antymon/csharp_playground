using NUnit.Framework;

namespace DynamicProgramming
{

	public class KnapsackTest
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
            Assert.AreEqual(15, Knapsack.GetMaximumValue(15, new int[] {2,1,10,2,4}, new int[] {2,1,4,1,12}));
            Assert.AreEqual(15, Knapsack.GetMaximumValue(15, new int[] { 2, 1,4, 10, 2}, new int[] { 2, 1, 12, 4, 1 }));
            Assert.AreEqual(15, Knapsack.GetMaximumValue(15, new int[] {4, 2, 1, 10, 2 }, new int[] {12, 2, 1, 4, 1 }));
        }

    }
}
