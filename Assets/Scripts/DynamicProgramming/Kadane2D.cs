namespace DynamicProgramming
{
    public class Kadane2D
    {
        //O(n^3) time algorithm to find greatest sum submatrix
        public static int GetMaxSumSubmatrixValue(int [][] matrix)
        {
            int[] columnSum;

            int maxVal = 0;

            for (int i = 0; i<matrix[0].Length; ++i)
            {
                columnSum = new int[matrix.Length];

                for (int j = i; j<matrix[0].Length; ++j)
                {
                    for(int k = 0; k<matrix.Length; k++)
                    {
                        columnSum[k] += matrix[k][j];
                    }

                    int currVal = Kadane1D.GetMaximumSumOfSubarray(columnSum);

                    if(currVal>maxVal)
                    {
                        maxVal = currVal;
                    }
                }
            }

            return maxVal;
        }
    }
}
