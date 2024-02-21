using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_1Y_CpEOOP_ListRecreation
{
    internal class Program
    {
        static int[] emulatedList = new int[] { };

        static void Main(string[] args)
        {
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Add(10);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(7);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(10);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(7);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(10);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(7);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Add(10);
            Console.WriteLine($"Emulated List has a length of {emulatedList.Length}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");


            Console.WriteLine($"\n\nDoes emulated list contain 7? : {Contains(7)}");
            Console.WriteLine($"The index of 7 is {IndexOf(7)}");
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Remove(7);
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            RemoveAt(1);
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            RemoveAll(10);
            Console.WriteLine($"Emulated List contains {DisplayContent()}");
            Insert(1, 5);
            Console.WriteLine($"Emulated List contains {DisplayContent()}");

            Console.ReadKey();
        }

        static void Add(int value)
        {
            int currLength = emulatedList.Length;
            int[] tempClone = new int[currLength];

            for (int x = 0; x < currLength; x++)
                tempClone[x] = emulatedList[x];

            emulatedList = new int[currLength + 1];

            for (int x = 0; x < currLength; x++)
                emulatedList[x] = tempClone[x];

            emulatedList[currLength] = value;
        }

        static string DisplayContent()
        {
            string message = "";

            //foreach(int num in emulatedList)
            //{
            //    message += num + "  ";
            //}
            for (int x = 0; x < emulatedList.Length; x++)
            {
                //    message += emulatedList[x].ToString() + "  ";
                message = message + emulatedList[x] + "  ";
            }

            return message;
        }

        static void Remove(int value)
        {
            int[] tempClone = new int[emulatedList.Length];
            bool numFound = false;
            int indexOffset = 0;

            // check if the 'List' contains the number
            if(Contains(value))
            {
                // transfer all values to the emulated list
                for (int x = 0; x < tempClone.Length; x++)
                    tempClone[x] = emulatedList[x];

                // redelare the emulated list with its new list
                emulatedList = new int[tempClone.Length - 1]; 

                for(int x = 0; x < tempClone.Length; x++)
                {
                    if (tempClone[x] == value && !numFound)
                    {
                        numFound = true;
                        indexOffset = 1;
                    }
                    else
                    {
                        emulatedList[x - indexOffset] = tempClone[x];
                    }
                }
            }
        }

        static bool Contains(int value)
        {
            for(int x = 0; x < emulatedList.Length; x++)
            {
                if (emulatedList[x] == value)
                    return true;
            }

            return false;
        }

        static void RemoveAt(int index)
        {
            if(index < emulatedList.Length && index > -1) 
            {
                int[] tempClone = new int[emulatedList.Length];
                int indexOffset = 0;

                // transfer all values to the emulated list
                for (int x = 0; x < tempClone.Length; x++)
                    tempClone[x] = emulatedList[x];

                // redeclare the emulated list with its new list
                emulatedList = new int[tempClone.Length - 1];

                for(int x = 0; x < tempClone.Length; x++)
                {
                    if (x == index)
                        indexOffset = 1;
                    else
                        emulatedList[x - indexOffset] = tempClone[x];
                }
            }
        }

        static void RemoveAll(int value)
        {
            while (Contains(value))
                Remove(value);
        }

        static int IndexOf(int value)
        {
            for (int x = 0; x < emulatedList.Length; x++)
                if (emulatedList[x] == value)
                    return x;

            return -1;
        }

        static void Insert(int index, int value)
        {
            if(index > emulatedList.Length)
                index = emulatedList.Length;

            int[] tempClone = new int[emulatedList.Length];
            int indexOffset = 0;

            // transfer all values to the emulated list
            for (int x = 0; x < tempClone.Length; x++)
                tempClone[x] = emulatedList[x];

            // redeclare the emulated list with its new list
            emulatedList = new int[tempClone.Length + 1];

            for(int x = 0; x < emulatedList.Length; x++)
            {
                if (x != index)
                    emulatedList[x] = tempClone[x - indexOffset];
                else
                {
                    indexOffset = 1;
                    emulatedList[x] = value;
                }
            }
        }
    }
}
