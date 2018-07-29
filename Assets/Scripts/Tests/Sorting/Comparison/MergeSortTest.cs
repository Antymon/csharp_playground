using NUnit.Framework;

namespace Sorting
{
    namespace Comparison
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
}
