using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class HexToInteger
    {
        public static int HexToInt(string hex)
        {
            List<int> list = new List<int>();//list to collect all the string characters as integers to do math with later

            int testAnswer = 0;
            //*****THIS FOLLOWING TEST IS DONE FOR TESTING PURPOSES TO ASSERT THAT THE ANSWER IS EQUAL TO THE BUILT IN .NET FUNCTIONALITY FOR HEXT TO INT CONVERSION'S ANSWER AT THE END OF THIS METHOD
            try
            {
                testAnswer = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);//this will throw an error if input includes letters not in the range ABCDEF
            }
            catch (Exception ex)
            {
                Console.WriteLine("you attempted to enter a hexadecimal value with letters outside of the acceptable range ABCDEF", ex.Message, ex.Data);
            }
                
            
            //END TESTING

            for (int i = 0; i < hex.Length; i++)
            {

                //can check here that letter inputs do go outsdie ABCDEF:
                int num;//only using tryparse for testing
                if (!int.TryParse(hex[i].ToString(), out num))//if the input char at this point in the string is a letter then...
                {
                    Debug.Assert(hex[i] - 'A' <= 5 && hex[i] - 'A' >= 0);//ensure that it is within the proper range
                }

                if (hex[i] - 'A' <= 5 && hex[i] - 'A' >= 0)//this does not rely on tryparse like the old if conditional below, instead it just checks that the letters are within the ascii range of ABCDEF, which also means you will get an error if you use a letter beyond outside of these
                //int num;
                //if (!int.TryParse(hex[i].ToString(), out num))//if you can't convert the char in the hexstring to an integer then it must be a letter, and the letters must be converted to integers
                {
                    //Console.WriteLine("old: "+hex[i]);
                    int temp;
                    temp = (char)hex[i] - 55;//add the proper value to convert these letters ABCDEF to the correct numbers 10,11,12,13,14,15
                    list.Add(temp);
                }
                else
                {
                    list.Add((int)hex[i] - '0');
                }
            }

            double sum = 0;
            double temporary;
            int exponent = 0;

            //now convert the individual elements of the list to decimals and add them together
            for (int i = list.Count() - 1; i >= 0; i--)
            {
                temporary = (list[i] * Math.Pow(16, exponent++));
                sum += temporary;
            }

            Debug.Assert(testAnswer == (int)sum);//test to ensure conversion worked correctly

            return (int)sum;
        }
    }
}
