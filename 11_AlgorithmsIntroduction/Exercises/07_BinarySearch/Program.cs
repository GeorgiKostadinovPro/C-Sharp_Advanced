using System;
using System.Linq;

namespace _07_BinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int elementToSearch = int.Parse(Console.ReadLine());

            int index = BinarySearch.IndexOf(numbers, elementToSearch);

            Console.WriteLine(index);
        }
    }
    
    public class BinarySearch
    { 
       public static int IndexOf(int[] nums, int elementToSearch)
        {
            Array.Sort(nums);

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == elementToSearch)
                {
                    return mid;
                }

                if (nums[mid] < elementToSearch)
                {
                    start = mid + 1;
                }
                else if (nums[mid] > elementToSearch)
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}
