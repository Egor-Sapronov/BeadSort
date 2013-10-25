using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = new int[10];
            Console.Write("Unsorted ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 10);
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            Program temp=new Program();
            int[] sorted = temp.BeadSort(arr);
            Console.Write("Sorted   ");
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }

            Console.ReadKey();
        }

        public int[] BeadSort(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i]>max)                   
                    max = arr[i];

            char[,] grid=new char[arr.Length,max];
            int[] levelCount = new int[max];
            for (int i = 0; i < max; i++)
			{
			    levelCount[i]=0;
                for (int j = 0; j < arr.Length; j++)
                    grid[j,i]=char.Parse("_");
			}


            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                for (int J = 0; num>0 ; J++)
                {
                    grid[levelCount[J]++, J] = char.Parse("*");
                    num--;
                }
            }

            int[] sorted = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int putt = 0;
                for (int j = 0; (j < max) && (grid[arr.Length - 1 - i, j] == char.Parse("*")); j++)                   
                    putt++;                  
                sorted[i] = putt;
            }
            return sorted;
        }
    }
}
