using NUnit.Framework;

public class MatrixChainTest
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
    public void GivenNullImput_CostIs0()
    {
        Assert.AreEqual(0, MatrixChain.GetOptimalMatrixChainMultipliactionCost(null));
    }

    [Test]
    public void GivenNonPositiveDimension_CostIs0()
    {
        //todo
    }

    [Test]
    public void GivenSingleDimension_CostIs0()
    {
        Assert.AreEqual(0, MatrixChain.GetOptimalMatrixChainMultipliactionCost(new int[] { 10 }));
    }

    [Test]
    public void GivenSingleMatrix_CostIs0()
    {
        Assert.AreEqual(0, MatrixChain.GetOptimalMatrixChainMultipliactionCost(new int[] { 10, 20}));
    }

    [Test]
    public void Given2Matrices_CostIsNot0()
    {
        Assert.AreEqual(6000, MatrixChain.GetOptimalMatrixChainMultipliactionCost(new int[] { 10, 20, 30 }));

        /*
            There are only two matrices of dimensions 10x20 and 20x30. So there 
            is only one way to multiply the matrices, cost of which is 10*20*30
        */
    }


    [Test]
	public void GivenMatricesOfSize3_OptimalChainIsSelected()
	{
        Assert.AreEqual(26000, MatrixChain.GetOptimalMatrixChainMultipliactionCost(new int[] { 40, 20, 30, 10, 30 }));

        /*
            There are 4 matrices of dimensions 40x20, 20x30, 30x10 and 10x30.
            Let the input 4 matrices be A, B, C and D.The minimum number of
            multiplications are obtained by putting parenthesis in following way
            (A(BC))D-- > 20 * 30 * 10 + 40 * 20 * 10 + 40 * 10 * 30

        */

        Assert.AreEqual(30000, MatrixChain.GetOptimalMatrixChainMultipliactionCost(new int[] { 10, 20, 30, 40, 30 }));

        /*
            There are 4 matrices of dimensions 10x20, 20x30, 30x40 and 40x30.
            Let the input 4 matrices be A, B, C and D.The minimum number of
            multiplications are obtained by putting parenthesis in following way
            ((AB) C)D-- > 10 * 20 * 30 + 10 * 30 * 40 + 10 * 40 * 30
        */
    }

}
