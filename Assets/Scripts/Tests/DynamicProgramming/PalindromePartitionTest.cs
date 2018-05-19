using NUnit.Framework;

namespace DynamicProgramming
{

	public class PalindromicPartitionTest
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
		public void GivenNullOrEmptyString_PalindromeCostIs0()
		{
            Assert.AreEqual(0, PalindromicPartition.GetPalindromePartitonCost(string.Empty));
            Assert.AreEqual(0, PalindromicPartition.GetPalindromePartitonCost(null));
        }

        [Test]
        public void GivenStringSize1_PalindromeCostIs0()
        {
            Assert.AreEqual(0, PalindromicPartition.GetPalindromePartitonCost("a"));
        }

        [Test]
        public void GivenStringOf2Palindromes_CostIs1()
        {
            Assert.AreEqual(1, PalindromicPartition.GetPalindromePartitonCost("ab"));
            Assert.AreEqual(1, PalindromicPartition.GetPalindromePartitonCost("abb"));
            Assert.AreEqual(1, PalindromicPartition.GetPalindromePartitonCost("caba"));
            Assert.AreEqual(1, PalindromicPartition.GetPalindromePartitonCost("ccaba"));
        }

        [Test]
        public void GivenStringOf3Palindromes_CostIs2()
        {
            Assert.AreEqual(2, PalindromicPartition.GetPalindromePartitonCost("abc"));
            Assert.AreEqual(2, PalindromicPartition.GetPalindromePartitonCost("abcac"));
            Assert.AreEqual(2, PalindromicPartition.GetPalindromePartitonCost("dabacac"));
            Assert.AreEqual(2, PalindromicPartition.GetPalindromePartitonCost("ddabacac"));
            Assert.AreEqual(2, PalindromicPartition.GetPalindromePartitonCost("dadabacac"));
        }

        [Test]
        public void GivenStringOf4Palindromes_CostIs3()
        {
            Assert.AreEqual(3, PalindromicPartition.GetPalindromePartitonCost("ababbbabbababa"));
        }

    }
}
