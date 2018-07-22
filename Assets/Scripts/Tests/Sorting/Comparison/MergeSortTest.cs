using NUnit.Framework;

namespace Sorting
{
    namespace Comparison
    {
        public class MergeSortTest
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
                var input = new[] { 1, 0, -1, 0, 1, -1 };

                MergeSort.Sort(input);

                Assert.AreEqual(new[] { -1, -1, 0, 0, 1, 1 }, input);
            }

        }
    }
}
