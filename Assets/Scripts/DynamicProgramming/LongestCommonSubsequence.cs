using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DynamicProgramming
{
    public static class LongestCommonSubsequence
    {
        //time O(mn) space O(mn)
        public static List<int> GetLongestSubsequence(List<int> seq1, List<int> seq2)
        {
            int[][] sequenceLengths = new int[seq1.Count + 1][];

            //zero padded first row and column
            sequenceLengths[0] = new int[seq2.Count + 1];

            for (int i = 1; i <= seq1.Count; ++i)
            {
                sequenceLengths[i] = new int[seq2.Count + 1];
                for (int j = 1; j <= seq2.Count; ++j)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                    {
                        sequenceLengths[i][j] = sequenceLengths[i - 1][j - 1] + 1;
                    }
                    else if (sequenceLengths[i - 1][j] > sequenceLengths[i][j - 1])
                    {
                        sequenceLengths[i][j] = sequenceLengths[i - 1][j];
                    }
                    else
                    {
                        sequenceLengths[i][j] = sequenceLengths[i][j - 1];
                    }
                }
            }

            return GetResult(sequenceLengths, seq1, seq2);
        }

        //time O(m+n)
        private static List<int> GetResult(int[][] input, List<int> seq1, List<int> seq2)
        {
            var output = new List<int>();

            int i = seq1.Count;
            int j = seq2.Count;

            while (i != 0 && j != 0)
            {
                if (seq1[i - 1] == seq2[j - 1])
                {
                    output.Add(seq1[i - 1]);
                    --i;
                    --j;
                }
                else if (input[i - 1][j] > input[i][j - 1])
                {
                    --i;
                }
                else
                {
                    --j;
                }
            }


            output.Reverse();
            return output;
        }
    }
}