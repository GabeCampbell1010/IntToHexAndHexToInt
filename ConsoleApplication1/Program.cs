using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //integer to hex is below and hex to integer is in another file in this project HexToInteger
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine(IntegerToHex.IntToHex(241));

            Console.WriteLine(HexToInteger.HexToInt("FF"));//make sure to check input to not permit letters above F?

            //Console.WriteLine(IntegerToHex.IntToHex(HexToInteger.HexToInt("A5")));

            Console.ReadKey();
        }
    }


    public class IntegerToHex
    {
        public static string IntToHex(int value)
        {
            //*****THIS FOLLOWING LINE IS DONE FOR TESTING PURPOSES TO ASSERT THAT THE ANSWER IS EQUAL TO THE BUILT IN .NET FUNCTIONALITY FOR INT TO HEX CONVERSION'S ANSWER AT THE END OF THIS METHOD
            string hexValue = value.ToString("X");//THIS IS NOT USED TO DETERMINE THE ANSWER!!!
            //END TESTING LINES
            

            int quotient = 1;
            int remainder;
            List<int> list = new List<int>();
            string answer = "";
            string thisString;
            char thisChar;
            List<int> listReversed = new List<int>();

            //populate the list with the correct integer values as per the necessary calculations
            while (quotient != 0)
            {
                quotient = value / 16;
                remainder = value % 16;
                list.Add(remainder);
                value = quotient;
            }

            //if a value in the list is greater than 9 then convert it to the apropriate number corresponding to its ascii letter
            for (int i = 0; i< list.Count(); i++)
            {
                Debug.Assert(list[i] <= 16 && list[i] >= 0);
                if(list[i] > 9)
                {
                    int numChar = (list[i] - 10 + 65);//of course I could put + 55 here but it is less confusing to convert it first to 10 = 0, 11 = 1, etc...and then add 65 ('A' = 65), so that 10 = 'A' etc... 
                    list[i] = (char)numChar;//this (char) cast is actually unnecessary I think
                    
                }
            }
       
            //reverse the list to be in proper hexadecimal order
            for(int i = 0; i < list.Count(); i++)
            {
                listReversed.Add(list[list.Count() - 1 - i]); 
            }
            list = listReversed;

            //concatenate the whole list into a string and then return that string, taking into account that your above 10 integers must be converted into char-type letters and then into strings to concatenate with the answer string
            foreach (int n in list)
            {
                if (n < 10)
                {
                    thisString = n.ToString();
                }
                else
                {
                    thisChar = (char)n;//if above 16 then use the temporary variable thisChar to convert the integer to a corresponding char type letter
                    thisString = thisChar.ToString();//and then make that char letter into a string letter 
                }
                answer += thisString;//and finall concatenate
            }

            //here the test hexValue conversion is used to assert that our answer is correct
            Debug.Assert(answer == hexValue);

            return answer;
        }
    }
}