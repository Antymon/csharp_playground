using NUnit.Framework;

namespace DynamicProgramming
{

	public class OptimalBinarySearchTreeTest
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
            Assert.AreEqual(2.75f,OptimalBinarySearchTree.GetOptimalSearchCost(new[] {.15f,.10f,.05f,.10f,.20f}, new[] {.05f,.10f,.05f,.05f, .05f, .10f }));
		}

	}
}
