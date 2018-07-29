using NUnit.Framework;

namespace Parallel.Sorting.Comparison
{

	public class MergeSortTest : SortTest
	{
        [SetUp]
        public override void SetUp()
        {
            this.sortingAlgorithm = new MergeSort();
        }
    }
}
