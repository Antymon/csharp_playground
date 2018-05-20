using NUnit.Framework;

namespace DynamicProgramming
{

	public class Kadane2DTest
	{

		[SetUp]
		public void SetUp()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}
        /*
        
          
Assert.AreEqual(0, Kadane2D.GetMaxSumSubmatrixValue(
    new int[][] {
    new int[]{ },
    new int[]{ },
    new int[]{ },
    new int[]{ },
}));
         */

		[Test]
		public void t()
		{
            Assert.AreEqual(29, Kadane2D.GetMaxSumSubmatrixValue(
                new int[][] {
                    new int[]{ 1,2,-1,-4,-20},
                    new int[]{ -8,-3,4,2,1},
                    new int[]{ 3,8,10,1,3},
                    new int[]{ -4,-1,1,7,-6},
                }));
		}

	}
}
