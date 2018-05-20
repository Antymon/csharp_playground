namespace DynamicProgramming
{
    public static class Kadane1D
    {
        public static int GetMaximumSumOfSubarray(int[] input)
        {
            int maxVal = 0;
            int curVal = 0;

            for(int i = 0; i<input.Length; ++i)
            {
                if (input[i] > 0)
                {
                    curVal += input[i];
                    
                    if(curVal>maxVal)
                    {
                        maxVal = curVal;
                    }
                }
                else if (curVal+input[i] > 0)
                {
                    curVal += input[i];
                }
                else
                {
                    curVal = 0;
                }
            }


            return maxVal;
        }
    }
}
