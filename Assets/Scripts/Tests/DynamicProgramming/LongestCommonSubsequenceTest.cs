using NUnit.Framework;
using System.Collections.Generic;

public class LongestCommonSubsequenceTest
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
        Assert.AreEqual(new List<int> { 2, 4, 6 }, LongestCommonSubsequence.GetLongestSubsequence(new List<int>{1,2,3,4,5,6}, new List<int>{2,4,6,8,10}));
	}

}
