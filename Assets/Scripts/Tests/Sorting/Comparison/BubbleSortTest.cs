using NUnit.Framework;

namespace Sorting
{
    namespace Comparison
    {
        public class BubbleSortTest : SortTest
        {
            [SetUp]
            public override void SetUp()
            {
                this.sortingAlgorithm = new BubbleSort();
            }
        }
    }
}
