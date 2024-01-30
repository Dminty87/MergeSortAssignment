using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] ints = new int[rand.Next(10,15)];

            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rand.Next(1,100);
            }

            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            ints = MergeSort(ints);
            
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }

        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int middleIndex = array.Length / 2;

            int[] leftHalf = new int[middleIndex];
            int[] rightHalf = new int[array.Length - middleIndex];

            for (int i = 0; i < middleIndex; i++)
            {
                leftHalf[i] = array[i];
            }

            for (int i = middleIndex; i < array.Length; i++)
            {
                rightHalf[i - middleIndex] = array[i];
            }
            
            return Merge(MergeSort(leftHalf), MergeSort(rightHalf));
        }

        public static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] result = new int[leftArray.Length + rightArray.Length];

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    result[leftIndex + rightIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[leftIndex + rightIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

            }

            if (leftIndex >= leftArray.Length)
            {
                while (rightIndex < rightArray.Length)
                {
                    result[leftIndex + rightIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
            }
            else
            {
                while (leftIndex < leftArray.Length)
                {
                    result[leftIndex + rightIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
            }

            return result;
        }
    }
}
