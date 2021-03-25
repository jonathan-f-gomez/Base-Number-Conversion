using System;

namespace EX_1E
{
    class Program
    {
        public static void Header()
        {
            try
            {
                Console.Write("Please enter the integer to convert: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Please enter the base to convert from [ 2 | 8 | 10]: ");
                int numBase = int.Parse(Console.ReadLine());



                if ( (numBase == 2 && IsBinary(number) == true) || numBase == 8 || numBase == 10)
                {
                    Console.WriteLine($"Number: { number}, base : {numBase}\n");
                    switch (numBase)
                    {
                        case 2:
                            Console.WriteLine($"\t{number} to Octal is: {BinToOct(number)}");
                            Console.WriteLine($"\t{number} to Decimal is: {BinToDec(number)}");
                            break;
                        case 8:
                            Console.WriteLine($"\t{number} to Binary is: {OctToBin(number)}");
                            Console.WriteLine($"\t{number} to Decimal is: {OctToDec(number)}");
                            break;
                        case 10:
                            Console.WriteLine($"\t{number} to Binary is: {DecToBin(number)}");
                            Console.WriteLine($"\t{number} to Octal is: {DecToOct(number)}");
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Console.Clear();
                Header();
            }
            
        }

        public static int BinToDec(int number)
        {           
                int conversion = number;
                int nextBinVal = 1;
                int decimalValue = 0;

                while (conversion > 0)
                {
                    int divint = conversion % 10;
                    conversion /= 10;
                    decimalValue += divint * nextBinVal;
                    nextBinVal *= 2; //as we go through each bin value it doubles as we increase
                }

                return decimalValue;
                      
        }

        public static string BinToOct(int number)
        {
            int decimalValue = BinToDec(number);

            return DecToOct(decimalValue); //Google fu showed that we cannot directly convery bin to oct, we have to convert bin to dec, then dec to oct.
        }

        public static bool IsBinary(int number)
        {
            char[] greaterThanOne = { '2', '3', '4', '5', '6', '7', '8', '9'};

            string checkNum = number.ToString();

            //Checks the String against the char[] and returns the first index of the string that contains the character in the array
            int count = checkNum.IndexOfAny(greaterThanOne); 
            
            //If there is no character in the array it defaults to -1 
            if (count < 0) return true;
            else return false;           
        }

        public static int OctToDec(int number)
        {
            int conversion = number;
            int counter = 0;
            int output = 0;

            while (conversion > 0)
            {
                int working = conversion % 10;
                output += (working * (int)Math.Pow(8, counter));

                conversion /= 10;
                counter++;
            }
            output += conversion;
            return output;
        }

        public static string OctToBin(int number)
        {
            int decimalVal = OctToDec(number);
            return DecToBin(decimalVal);
        }

        public static string DecToBin(int number)
        {
            int num = number;

            string numString = "";

            while (num > 1)
            {
                numString += (num % 2);
                num /= 2;
            }
            numString += num;

            return ReverseString(numString);
        }

        public static string DecToOct(int number)
        {
            int num = number;

            string numString = "";

            while (num > 7)
            {
                numString += (num % 8);
                num /= 8;
            }
            numString += num;

            return ReverseString(numString);
        }

        public static string ReverseString(string stringInput)
        {             
            char[] charArray = stringInput.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void Main(string[] args)
        {
            var tryAgain = true;
            while (tryAgain == true)
            {
                Header();

                Console.WriteLine("\n\tTry again? \n\t[Yes] | No");
                var cont = Console.ReadLine().ToLower();
                if (cont == "no")
                {
                    tryAgain = false;
                }
                else Console.Clear();
            }
            
        }
    }
}
