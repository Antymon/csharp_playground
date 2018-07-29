using NUnit.Framework;



public abstract class SortTest
{
    protected ISortable sortingAlgorithm;

    public abstract void SetUp();

	[TearDown]
	public void TearDown()
	{
        sortingAlgorithm = null;
	}

    [Test]
    public void TestManyElements()
    {
        var input = new[] { 1, 0, -1, 0, 1, -1 };

        sortingAlgorithm.Sort(input);

        Assert.AreEqual(new[] { -1, -1, 0, 0, 1, 1 }, input);
    }

    [Test]
    public void TestEmpty()
    {
        var input = new int[0];

        sortingAlgorithm.Sort(input);

        Assert.AreEqual(0, input.Length);
    }

    [Test]
    public void TestOneElement()
    {
        var input = new[] { 1 };

        sortingAlgorithm.Sort(input);

        Assert.AreEqual(new[] { 1 }, input);
    }

    [Test]
    public void Test2Elements()
    {
        var input = new[] { 1, -1};

        sortingAlgorithm.Sort(input);

        Assert.AreEqual(new[] { -1, 1 }, input);
    }

    [Test]
    public void Test3Elements()
    {
        var input = new[] { 1, 0, -1};

        sortingAlgorithm.Sort(input);

        Assert.AreEqual(new[] { -1, 0, 1 }, input);
    }

}

