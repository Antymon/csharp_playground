namespace Sorting
{
    namespace Comparison
    {
        public static class MergeSort
        {
            public static void Sort(int[] input)
            {
                Sort(input, 0, input.Length);
            }

            private static void Sort(int[] input, int first, int last)
            {
                if (last - first< 2)
                {
                    return;
                }
                int mid = (first + last) / 2;

                Sort(input, first, mid);
                Sort(input, mid, last);

                Merge(input, first, mid, last);
            }

            private static void Merge(int[] input, int first, int mid, int last)
            {
                int[] inputPart1 = new int[mid - first];
                int[] inputPart2 = new int[last - mid];

                for (int i = first, j = 0; i < mid; ++i)
                {
                    inputPart1[j] = input[i];
                    ++j;
                }
                for (int i = mid, j = 0; i < last; ++i)
                {
                    inputPart2[j] = input[i];
                    ++j;
                }

                int m = 0;
                int n = 0;

                for (int i = 0; i < last - first; ++i)
                {
                    if (n == inputPart2.Length)
                    {
                        input[first + i] = inputPart1[m];
                        ++m;
                    }
                    else if (m == inputPart1.Length)
                    {
                        input[first + i] = inputPart2[n];
                        ++n;
                    }
                    else if (inputPart1[m] <= inputPart2[n])
                    {
                        input[first + i] = inputPart1[m];
                        ++m;
                    }
                    else
                    {
                        input[first + i] = inputPart2[n];
                        ++n;
                    }
                }
            }
        }
    }
}
