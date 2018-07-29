namespace Sorting
{
    public class CountingSort : ISortable
    {
        public void Sort(int[] input)
        {
            if(input == null)
            {
                return;
            }

            int min = 0;
            int max = 0;

            GetMinMax(ref min, ref max, input);

            int[] count = new int[max - min + 1];

            for(int i=0;i<input.Length;i++)
            {
                int key = input[i] - min;
                count[key]++;
            }

            int totalCount = 0;

            for (int i = 0; i < count.Length; i++)
            {
                int oldCount = count[i];
                count[i] = totalCount;
                totalCount += oldCount;
            }

            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                int key = input[i] - min;
                output[count[key]] = input[i];
                count[key]++;
            }

            System.Array.Copy(output, input, input.Length);
        }

        public static void GetMinMax(ref int min, ref int max, int[] range)
        {
            min = int.MaxValue;
            max = int.MinValue;
            for (int i = 0; i < range.Length; ++i)
            {
                if(range[i]<min)
                {
                    min = range[i];
                }
                if(range[i]>max)
                {
                    max = range[i];
                }
            }
        }
    }
}
