using NUnit.Framework;
using UnityEngine;

public class FibTest
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
        var fib = new[] {1,1,2,3,5,8,13,21,34,55,89,144,233};

        for(int i =0; i< fib.Length; ++i)
        {
            Assert.AreEqual(fib[i], Fib.Get(i));
        }
    }

}
