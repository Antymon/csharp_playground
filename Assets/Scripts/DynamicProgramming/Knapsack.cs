namespace DynamicProgramming
{
    public static class Knapsack
    {

        // Use this for initialization
        public static int GetMaximumValue(int capacity, int[] itemValues, int[] itemCosts)
        {
            //optimalValues is 0 padded both from top and left

            int[][] optimalValues = new int[itemValues.Length+1][];

            optimalValues[0] = new int[capacity+1];

            for (int itemIndex = 1; itemIndex <= itemValues.Length; ++itemIndex)
            {
                optimalValues[itemIndex] = new int[capacity+1];

                for (int subCapacity = 1; subCapacity <= capacity; ++subCapacity)
                {
                    //for given capacity
                    int optimalValueForPreviousItem = optimalValues[itemIndex - 1][subCapacity];

                    if (subCapacity < itemCosts[itemIndex - 1])
                    {
                        optimalValues[itemIndex][subCapacity] = optimalValueForPreviousItem;
                        continue;
                    }

                    int currentValue = optimalValues[itemIndex - 1][subCapacity - itemCosts[itemIndex - 1]] + itemValues[itemIndex - 1];

                    if (currentValue > optimalValueForPreviousItem)
                    {
                        optimalValues[itemIndex][subCapacity] = currentValue;
                    }
                    else
                    {
                        optimalValues[itemIndex][subCapacity] = optimalValueForPreviousItem;
                    }
                }
            }

            return optimalValues[optimalValues.Length-1][optimalValues[optimalValues.Length - 1].Length-1];
        }
    }
}
