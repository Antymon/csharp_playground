namespace DynamicProgramming {

    public static class MatrixChain {

        //dimensions - 1st dimension of 1st 2D matrix followed by all 2nd dimensions of all matrices (in multiplication order)
        //O(n^3) time complexity
        //there is O(nlogn) alternative known based on triangulation

        public static int GetOptimalMatrixChainMultipliactionCost(int[] dimensions)
        {
            //everything below 2 matrices is ignored
            //2 matrices imply 3 dimensions
            if (dimensions == null || dimensions.Length < 3)
            {
                return 0;
            }

            //in matrix multiplication chains consecutive dimensions are shared by consecutive pairs
            //with exception of first dimension being specific only to first matrix
            int matrixCount = dimensions.Length - 1;

            //first index maps to chain's length
            //for clarity index 0 stands for chain of length 1
            //although cost for size 1 is always 0
            //and split index for size 1 is undefined
            //second index maps to 1st element of subchain within original chain
            //last subchain is equal to original chain and has only index 0
            int[][] multiplicationsCounts = new int[matrixCount][];

            //saving partitions indeces is only for the sake of printing ordered chain
            int[][] partitionIndeces = new int[matrixCount][];

            //for single matrix there is no multiplication cost
            multiplicationsCounts[0] = new int[matrixCount];

            //we consider every possible chain length starting from size 2
            for (int chainLength = 2; chainLength < dimensions.Length; ++chainLength)
            {
                //chain lenght indicates how many unique chains are possible within fixed size of original chain
                multiplicationsCounts[chainLength - 1] = new int[matrixCount - chainLength + 1];
                partitionIndeces[chainLength - 1] = new int[matrixCount - chainLength + 1];

                //we are considering chains of given length starting from different indeces withing original chain
                //effectively 'sliding' over original chain
                for (int chainIndex = 0; chainIndex < matrixCount - chainLength + 1; ++chainIndex)
                {
                    multiplicationsCounts[chainLength - 1][chainIndex] = int.MaxValue;

                    for (int chainPartitionIndex = chainIndex + 1; chainPartitionIndex < chainIndex + chainLength; ++chainPartitionIndex)
                    {
                        //chainMultiplicationsCount is a sum of 2 subchain counts (multiplication count within chain) and count of multiplying those subchains themselves
                        int chainMultiplicationsCount =
                            multiplicationsCounts[chainPartitionIndex - chainIndex - 1][chainIndex] +
                            dimensions[chainIndex] * dimensions[chainPartitionIndex] * dimensions[chainIndex + chainLength] +
                            multiplicationsCounts[chainLength - chainPartitionIndex + chainIndex - 1][chainPartitionIndex];

                        //if current partition has less multiplications than previously considered
                        if (chainMultiplicationsCount < multiplicationsCounts[chainLength - 1][chainIndex])
                        {
                            //save lowest known count and partition index at which count was achieved
                            multiplicationsCounts[chainLength - 1][chainIndex] = chainMultiplicationsCount;
                            partitionIndeces[chainLength - 1][chainIndex] = chainPartitionIndex;
                        }
                    }
                }
            }
            //print actual chain
            UnityEngine.Debug.Log(GetIndexedMultiplicationOrder(partitionIndeces, 0, matrixCount));

            return multiplicationsCounts[multiplicationsCounts.Length - 1][0];


        }

        //recursive method printing multiplication chain based on partition information give
        //it could be generelized to take (index1[,index2]) => output functor; that is a functor with optional second argument or 2 functors
        //this way it could not only print, but also perform actual multiplication or recalculate overall cost
        private static string GetIndexedMultiplicationOrder(int[][] partitionIndeces, int startIndex, int length)
        {
            if (length == 1)
            {
                return string.Format("{0}", startIndex);
            }
            else if (length == 2)
            {
                return string.Format("({0}*{1})", startIndex, startIndex + 1);
            }
            else
            {
                int partitionIndex = partitionIndeces[length - startIndex - 1][startIndex];

                string firstPartitionOrder = GetIndexedMultiplicationOrder(partitionIndeces, startIndex, partitionIndex - startIndex);
                string secondPartitionOrder = GetIndexedMultiplicationOrder(partitionIndeces, partitionIndex, length - partitionIndex);

                return string.Format("({0}*{1})", firstPartitionOrder, secondPartitionOrder);
            }
        }
    }
}