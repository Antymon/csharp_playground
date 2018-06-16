namespace DynamicProgramming
{

    public static class OptimalBinarySearchTree
    {
        //time complexity O(n^3)
        //space complexity O(n^2)
        //half of the space taken remains unused, diagonal repeated
        public static float GetOptimalSearchCost(float[] keyProbs, float[] dummyKeyProbs)
        {
            if (keyProbs == null || dummyKeyProbs == null || keyProbs.Length == 0 ||  dummyKeyProbs.Length != keyProbs.Length + 1)
            {
                return 0;
            }

            float[][] costs = new float[dummyKeyProbs.Length][];
            float[][] probSums = new float[dummyKeyProbs.Length][];

            //both costs and prob sums have same diagonal equal to dummyKeyProbs
            for (int i = 0; i < dummyKeyProbs.Length; ++i)
            {
                costs[i] = new float[dummyKeyProbs.Length];
                probSums[i] = new float[dummyKeyProbs.Length];
                costs[i][i] = dummyKeyProbs[i];
                probSums[i][i] = dummyKeyProbs[i];
            }

            for (int length = 1; length < dummyKeyProbs.Length; ++length)
            {
                for (int startIndex = 0; startIndex < dummyKeyProbs.Length - length; ++startIndex)
                {
                    float cost = float.MaxValue;
                    float probSum = 0;

                    for (int rootIndex = startIndex; rootIndex < startIndex + length; ++rootIndex)
                    {
                        //making given tree a root's subtree in a search tree increses the  search cost of latter by cost of former plus sum of probs in subtree
                        //it is due to fact that subtree's elements' depth increses by 1
                        float currentProbSum = probSums[startIndex][rootIndex] + probSums[rootIndex + 1][startIndex + length] + keyProbs[rootIndex];

                        float currentCost = costs[startIndex][rootIndex] + costs[rootIndex + 1][startIndex + length] + currentProbSum;

                        if(currentCost<cost)
                        {
                            cost = currentCost;
                            probSum = currentProbSum;
                        }
                    }

                    costs[startIndex][startIndex + length] = cost;
                    probSums[startIndex][startIndex + length] = probSum;
                }
            }

            return costs[0][keyProbs.Length];
        }
    }
}
