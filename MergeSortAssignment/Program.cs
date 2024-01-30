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
            //Create an int array with random length and values for testing
            Random rand = new Random();
            int[] ints = new int[rand.Next(10,15)];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rand.Next(1,100);
            }

            //Display the unsorted array
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }

            //Override the unsorted array with the sorted array returned from MergeSort
            ints = MergeSort(ints);

            //Display the sorted array on a new line
            Console.WriteLine();
            foreach (int i in ints)
            {
                Console.Write(i + " ");
            }

            //Keep the console open
            Console.ReadLine();

        }//Main

        public static int[] MergeSort(int[] array)
        {
            //Base case: if the array contains one or less elements, return it for recursion
            if (array.Length <= 1)
            {
                return array;
            }

            //Split the array into two halves
            //middleIndex is where the original array will be split
            int middleIndex = array.Length / 2;

            //Create arrays to store the left and right halves of the original array
            int[] leftHalf = new int[middleIndex];
            int[] rightHalf = new int[array.Length - middleIndex];

            //Populate the left array from the beginning to one element before the middleIndex
            for (int i = 0; i < middleIndex; i++)
            {
                leftHalf[i] = array[i];
            }

            //Populate the right array from middleIndex to the end
            //The corresponding indecies of the original array and the right array are offset by the value of middleIndex
            for (int i = middleIndex; i < array.Length; i++)
            {
                rightHalf[i - middleIndex] = array[i];
            }
            
            //Sort the left and right arrays recursively using MergeSort
            //then Merge the sorted arrays using Merge and return the sorted array
            return Merge(MergeSort(leftHalf), MergeSort(rightHalf));

        }//MergeSort

        public static int[] Merge(int[] leftArray, int[] rightArray)
        {
            //The merged array to be returned
            int[] result = new int[leftArray.Length + rightArray.Length];

            //indecies of the left and right (L/R) arrays that are currently being looked at
            //the index of the first element of each array that hasn't been added to the result array
            int leftIndex = 0;
            int rightIndex = 0;

            //As long as at least one of the L/R arrays has elements that haven't been added to the result array,
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                //compare the first unused element of each array
                //add the smaller element to the result array and move forward in the corresponding L/R array
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

            //Once all the elements of one L/R array have been added to the result array,
            //Determine whick L/R array still has elements to be added to the result array and add them
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

            //Return the result array
            return result;

        }//Merge

    }//Program

}//MergeSortAssignment
