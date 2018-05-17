public static class MatrixChain {

	public static int GetOptimalChain(int[] dimensions)
    {
        if(dimensions == null || dimensions.Length < 3)
        {
            return 0;
        }

        int matrixCount = dimensions.Length - 1;

        int[][] multiplicationsCount = new int[matrixCount][];
        int[][] splitIndexes = new int[matrixCount][];

        multiplicationsCount[0] = new int[matrixCount];

        for (int chainLength = 2; chainLength<dimensions.Length; ++chainLength)
        {
            multiplicationsCount[chainLength - 1] = new int[matrixCount - chainLength + 1];
            splitIndexes[chainLength - 1] = new int[matrixCount - chainLength + 1];

            for (int chainIndex = 0; chainIndex<matrixCount-chainLength+1; ++chainIndex)
            {
                multiplicationsCount[chainLength - 1][chainIndex] = int.MaxValue;

                for (int chainPartitionIndex = chainIndex + 1; chainPartitionIndex<chainIndex+chainLength; ++chainPartitionIndex)
                {
                    //need size 1
                    int cost =
                        multiplicationsCount[chainPartitionIndex - chainIndex - 1][chainIndex] + 
                        dimensions[chainIndex] * dimensions[chainPartitionIndex] * dimensions[chainIndex+chainLength] +
                        multiplicationsCount[chainLength - chainPartitionIndex + chainIndex - 1][chainPartitionIndex];

                    if(cost < multiplicationsCount[chainLength - 1][chainIndex])
                    {
                        multiplicationsCount[chainLength - 1][chainIndex] = cost;
                        splitIndexes[chainLength - 1][chainIndex] = chainPartitionIndex;
                    }
                }
            }
        }

        return multiplicationsCount[multiplicationsCount.Length-1][0];
    }


}
