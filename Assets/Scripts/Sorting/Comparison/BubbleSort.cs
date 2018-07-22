namespace Sorting
{
    namespace Comparison
    {
        public static class BubbleSort
        {
            public static void Sort(int[] input)
            {
                int lastSwapIndex;
                int range = input.Length;

                do
                {
                    lastSwapIndex = -1;

                    for (int i = 1; i < range; ++i)
                    {
                        if (input[i] < input[i - 1])
                        {
                            int temp = input[i];
                            input[i] = input[i - 1];
                            input[i - 1] = temp;

                            lastSwapIndex = i;
                        }
                    }

                    range = lastSwapIndex;

                } while (lastSwapIndex != -1);
            }
        }
    }
}
