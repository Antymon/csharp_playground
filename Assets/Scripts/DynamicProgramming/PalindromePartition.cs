namespace DynamicProgramming
{
    //palindrome is a string which reads same left-to-right and right-to-left
    public static class PalindromicPartition
    {
        /* what's the minimal cost of splitting given string in palindromes 
         * O(n^2) time complexity
         */

        public static int GetPalindromePartitonCost(string input)
        {
            if(string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return 0;
            }

            bool[][] palindromeRegister = new bool[input.Length][];
            palindromeRegister[0] = new bool[input.Length];
            palindromeRegister[1] = new bool[input.Length - 1];

            for (int index = 0; index < palindromeRegister[0].Length; ++index)
            {
                palindromeRegister[0][index] = true;
            }

            for (int index = 0; index < palindromeRegister[1].Length; ++index)
            {
                palindromeRegister[1][index] = input[index] == input[index + 1];
            }

            for (int length = 3; length <= input.Length; ++length)
            {
                palindromeRegister[length - 1] = new bool[input.Length - length + 1];

                for (int index = 0; index < palindromeRegister[length-1].Length; ++index)
                {
                    palindromeRegister[length - 1][index] = input[index] == input[index + length - 1] && palindromeRegister[length - 3][index+1] ;
                }
            }

            int[] palindromeCost = new int[input.Length];

            for (int length = 2; length <= input.Length; ++length)
            {
                if(palindromeRegister[length-1][0])
                {
                    palindromeCost[length - 1] = 0;
                    continue;
                }

                int cost = int.MaxValue;

                for (int index = 1; index < length; ++index)
                {
                    if(palindromeRegister[length-index-1][index] && palindromeCost[index - 1] + 1 < cost)
                    {
                        cost = palindromeCost[index - 1] + 1;
                    }
                }

                palindromeCost[length - 1] = cost;

            }

            return palindromeCost[palindromeCost.Length-1];
        }
    }
}