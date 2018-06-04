using NUnit.Framework;

namespace Sorting
{

    public class BubbleSortTest
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

            BubbleSort.Sort(input);

            Assert.AreEqual(new[] { -1, -1, 0, 0, 1, 1 }, input);
        }

        //Todo overflow checks

    }
}
