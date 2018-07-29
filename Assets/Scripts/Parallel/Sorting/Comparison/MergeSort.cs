using System;
using System.Threading;

namespace Parallel
{
    namespace Sorting
    {
        namespace Comparison
        {
            public class MergeSort : ISortable
            {
                //parallel merge sort
                //main trickery is within the merge method
                //span is Theta(lg^3n)
                //work is Theta(nlgn) (serial merge sort complexity)
                //thus parallelism is Theta(nlgn)/Theta(lg^3n)=Theta(n/lg^2n)
                public void Sort(int[] input)
                {
                    if (input.Length < 2)
                        return;

                    var output = new int[input.Length];

                    Sort(input, 0, input.Length, output, 0);

                    Array.Copy(output, input, input.Length);
                }

                private void Sort(int[] input, int first, int last, int[] output, int firstOutput)
                {
                    int localLength = last - first;

                    if (localLength < 2)
                    {
                        if (last > first)
                        {
                            output[firstOutput] = input[first];
                        }
                        return;
                    }

                    int[] tempOutput = new int[localLength];

                    int mid = (first + last) / 2;
                    int localMid = localLength / 2;

                    var worker = new Thread(() =>
                        Sort(input, first, mid, tempOutput, 0)
                    ); worker.Start();

                    Sort(input, mid, last, tempOutput, localMid);

                    worker.Join();

                    //tempOutput becomes an input to merge
                    Merge(tempOutput, 0, localMid, localMid, localLength, output, firstOutput);
                }

                //recursive parallel merge
                //this is main difference to serial merge
                //serial work complexity of Merge is Theta(n)
                //span of Merge is Theta(lg^2n)
                //therefore parallelism = Theta(n/lg^2n)

                //1) take 2 sorted arrays
                //and long output with index where write can start
                private void Merge(int[] input, int first1, int last1, int first2, int last2, int[] output, int firstOutput)
                {
                    //keep 1st array at least as long as 2nd or longer
                    //to balance out lengths of arrays between calls
                    //and never run out empty of just one array with other having more than one element
                    if(last2-first2>last1-first1)
                    {
                        int tempFirst1 = first1;
                        int tempLast1 = last1;

                        first1 = first2;
                        last1 = last2;
                        first2 = tempFirst1;
                        last2 = tempLast1;
                    }

                    //if longer array is 0, we are done
                    if(last1-first1 == 0)
                    {
                        return;
                    }

                    //2) pick mediane of longer one
                    int mid1 = (last1 + first1) / 2;
                    int mid1Val = input[mid1];
                    //3) get split index of shorter one by previous mediane
                    int mid2 = FindMidIndex(input, first2, last2, mid1Val);

                    //4) set mediane in final place
                    int midOutput = firstOutput + mid1 - first1 + mid2 - first2;
                    output[midOutput] = mid1Val;
                    
                    //5) call for 1st pair halves
                    var worker = new Thread(() =>
                        Merge(input, first1, mid1, first2, mid2, output, firstOutput)
                    );
                    worker.Start();

                    //6) call for other pair of halves
                    Merge(input, mid1+1, last1, mid2, last2, output, midOutput+1);

                    worker.Join();
                }

                //serial binary search on sorted array
                //find index within array.length
                //such that values to the left are no bigger than value
                //and values to the right are no smaller than value
                private int FindMidIndex(int[] input, int first, int last, int val)
                {
                    //array is non empty
                    if (last - first > 0)
                    {
                        int mid = (first + last) / 2;
                        if(input[mid]>val)
                        {
                            return FindMidIndex(input, first, mid, val);
                        }
                        else
                        {
                            //we already know value for index mid is smaller so we start with one bigger index
                            return FindMidIndex(input, mid+1, last, val);
                        }
                    }

                    //array is empty so there is only one possible index
                    return first;

                }
            }
        }
    }
}