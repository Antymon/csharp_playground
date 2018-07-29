using NUnit.Framework;

namespace Sorting
{

	public class CountingSortTest : SortTest
	{
        //Todo overflow checks

        [SetUp]
        public override void SetUp()
        {
            this.sortingAlgorithm = new CountingSort();
        }
    }
}
