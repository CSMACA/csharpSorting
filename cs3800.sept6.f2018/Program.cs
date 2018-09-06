using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

/*
 * Design, test and implement a program that creates and uses an
 * unsorted list of random integers (varying list lengths). Keep track of
 * elapsed time to create the lists.
 * You will then sort your lists using a bubble sort and one other sort of your choosing.
 * You will track elapsed time for list creating and also elapsed time for sorting.
 * Also keep count of the number of comparisons done in each of the sorts.
 */

//README
//To compile on Linux (Bullwinkle), type 'mcs Program.cs'. 
//This generates an .exe which will have to be transferred to a Windows machine to run.
namespace cs3800.sept6.f2018
{
    class Program
    {
        static Random r = new Random(); //Initialize random variable, determined by system time.
        static int[] genRandList()
        {
            var stopwatch = Stopwatch.StartNew();
            ////Generate array with random length between 0 and 1000 inclusive.
            //Found that if the value here in Next() was too large, or not set, the program throws an out of memory exception.
            //Would not reccomend excessivley large values.
            int[] genList = new int[r.Next(1000)]; 
            

            //Fill list with random integers.
            for (int i = 0; i < genList.Length; i++)
            {
                genList[i] = r.Next(1000); //limited to 1000 for readability, can go higher if necessary.
            }
            //End stopwatch timer.
            stopwatch.Stop();
            Console.WriteLine("List of length {1} took {0} seconds to create and fill.", stopwatch.Elapsed, genList.Length);
            return genList;
        }
        //Global variable to hold the random list so that both sorts receive the exact same list.
        static int[] staticGeneratedList = genRandList(); 
        static void Main(string[] args)
        {
            //Initalize Stopwatch, a directive used to track elapsed time for debugging.
            var stopwatch = new Stopwatch();
            int[] Bubblenumber = staticGeneratedList;
            bool genericFlag = true;
            int temp;
            int listLength = Bubblenumber.Length;
            

            //Implementation of bubble sort.
            //Start stopwatch to track sort times.
            stopwatch.Start();
            int comparisons = 0; //Variable to track the number of comparisons within the bubble sort.
            for (int i = 1; (i <= (listLength - 1)) && genericFlag; i++)
            {
                genericFlag = false;
                for (int j = 0; j < (listLength - 1); j++)
                {
                    if (Bubblenumber[j + 1] > Bubblenumber[j])
                    {
                        temp = Bubblenumber[j];
                        Bubblenumber[j] = Bubblenumber[j + 1];
                        Bubblenumber[j + 1] = temp;
                        genericFlag = true;
                        comparisons++;
                    }
                }
            }
            stopwatch.Stop(); //Stops stopwatch for bubble sort.
            //Output Bubble Sorted Array
            Console.WriteLine("List sorted with Bubble sort in {0} seconds, with {1} comparisons.", stopwatch.Elapsed,comparisons);
            foreach (int num in Bubblenumber)
            {
                Console.Write("\t {0}", num); //Tabs in between for readability.
            }
            Console.WriteLine(); //readability

            

            //For my second sort, I'm going to switch the data type to List<>
            //because it uses QuickSort as it's default included sorting algorithm
            //which should produce significantly faster sort times.

            var listholder = staticGeneratedList;
            List<object> list = listholder.Cast<object>().ToList(); //Converting generated array into a list object.

            var stopw2 = Stopwatch.StartNew();
            //One step, included QuickSort. 
            //Hit F12 while hovering ".Sort", or follow this link to documentation:
            //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=netframework-4.7.2
            list.Sort();
            stopw2.Stop();

            //Output QuickSorted Array
            Console.WriteLine("List of length {1} sorted with Internal QuickSort in {0} seconds.", stopw2.Elapsed, list.Count);
            foreach (int num in list)
            {
                Console.Write("\t {0}", num); //Tabs in between for readability.
            }
            Console.Read();
        }

    }

}