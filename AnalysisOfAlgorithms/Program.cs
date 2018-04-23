using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfAlgorithms
{
    /// <summary>
    /// Array of int takes 8(refrence) + 2N + 24 bytes
    /// </summary>
    class Program
    {
        /// <summary>
        /// 30, -40, -20, -10, 40, 0, 10, 5
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region - 3 SUM
            //int[] arr = { 30, -40, -20, -10, 40, 0, 10, 5 };
            int N = 8000;
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = i - N / 2;
            }

            var intime = DateTime.Now;

            BruteForceThreeSum(arr);
            Console.WriteLine(DateTime.Now.Subtract(intime));
            #endregion

            #region - Binary Search
            //int[] bsArray = { 6, 13, 14, 25, 33, 43, 51, 53, 64, 72, 84, 93, 95, 96, 97 };
            //intime = DateTime.Now;
            //BinarySearch(arr, 1998);
            //Console.WriteLine(DateTime.Now.Subtract(intime));
            #endregion

            #region - optimized three sum
            // int[] arr = { 30, -40, -20, -10, 40, 0, 10, 5 };

            intime = DateTime.Now;
            OptimizedThreeSum(arr);
            Console.WriteLine(DateTime.Now.Subtract(intime));
            #endregion

            Console.Read();
        }

        private static void BruteForceThreeSum(int[] arr)
        {
            int length = arr.Length;
            int count = 0;
            for (int i = 0; i < length - 2; i++)
            {
                for (int j = i + 1; j < length - 1; j++)
                {
                    for (int k = j + 1; k < length; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            //Console.WriteLine(arr[i] + ":" + arr[j] + ":" + arr[k]);
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static void OptimizedThreeSum(int[] arr)
        {
            Array.Sort(arr);
            int count = 0;
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    int num = arr[i] + arr[j];
                    if (BinarySearchFor3Sum(arr, -num, j + 1))
                    {
                        //Console.WriteLine($"Numbers: {arr[i]}, {arr[j]}, {-num} ");
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static bool BinarySearchFor3Sum(int[] bsArray, int num, int k)
        {
            int low = k;
            int high = bsArray.Length - 1;

            while (low <= high)
            {
                int m = (low + high) / 2;

                if (num > bsArray[m])
                {
                    low = m + 1;
                }
                else if (num < bsArray[m])
                {
                    high = m - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Binary search complexity is lg(n).
        /// </summary>
        /// <param name="bsArray"></param>
        /// <param name="num"></param>
        private static void BinarySearch(int[] bsArray, int num)
        {
            int low = 0;
            int high = bsArray.Length - 1;

            while (low <= high)
            {
                int m = (low + high) / 2;

                if (num > bsArray[m])
                {
                    low = m + 1;
                }
                else if (num < bsArray[m])
                {
                    high = m - 1;
                }
                else
                {
                    Console.WriteLine(bsArray[m] + " @ " + m);
                    return;
                }
            }

            Console.WriteLine("Not found");
        }
    }
}
