using System;

namespace MetoderLäxa
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = { 2, 3, 5, 7, 13 };
            string[] wordArray = { "jag", "hej", "hund", "katt", "lärare", "skola" };


            Console.WriteLine(AddArray(numArr));

            Console.WriteLine(Reverse_array(wordArray));

            FindBounds(numArr);
        }

        /**
         * En metod som tar in en lista av heltal och adderar samtliga tal sedan returnerar summan.
         */

        public static int AddArray(int[] numArray)
        {
            int sum = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                sum += numArray[i];
            }
            return sum;
        }

        /**
         * En metod som tar in en lista av ord och skriver ut dem i omvänd ordning
         */
        public static string Reverse_array(string[] strArray)
        {
            string reversedArray = "";

            for (int i = strArray.Length - 1; i >= 0; i--)
            {
                reversedArray += strArray[i];
                reversedArray += " ";
            }
            return reversedArray;
        }

        /**
         * En metod som tar in en lista av heltal sedan tar reda på det största och det minsta talet och returnera dem.
         */
        public static void FindBounds(int[] numArray)
        {
            int smallestNum = numArray[0];
            int greatestNum = numArray[0];

            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] < smallestNum)
                {
                    smallestNum = numArray[i];
                }
                else if (numArray[i] > greatestNum)
                {
                    greatestNum = numArray[i];
                }
            }
            Console.WriteLine("The Greatest number in the list is: " + greatestNum);
            Console.WriteLine("The smallest number in the list is: " + smallestNum);
        }
    }
}
