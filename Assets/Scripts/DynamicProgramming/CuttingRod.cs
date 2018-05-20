namespace DynamicProgramming
{
    //O(n^2) maximization of value (sum of composite pieces value) for finite resource (rod of given length)
    public static class CuttingRod
    {
        public static int GetOptimalCutValue(int rodLength, int[] prices)
        {
            if(prices == null || prices.Length == 0 || rodLength < 1)
            {
                return 0;
            }

            int[] optimalValues = new int[rodLength];

            for (int length = 1; length <= rodLength; ++length)
            {
                optimalValues[length - 1] = prices[length - 1];

                for (int sublength = 1; sublength < length; ++sublength)
                {
                    int value = optimalValues[sublength - 1] + prices[length - sublength - 1];

                    if(value > optimalValues[length - 1])
                    {
                        optimalValues[length - 1] = value;
                    }
                }
            }

            return optimalValues[rodLength - 1];
        }
    }
}