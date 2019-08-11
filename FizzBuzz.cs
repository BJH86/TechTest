using System;
using System.Collections.Generic;
using System.Text;

namespace URL_Parser
{
    class FizzBuzz
    {
        // Pass 2 ints to the method, plus a maximum number to count
        public static void FBuzz(int num1, int num2, int max)
        {
            for (int i = 1; i <= max; i++) {
                if (i%num1 == 0 && i%num2 == 0) { Console.WriteLine("FIZZBUZZ"); }
                    else if (i%num1 == 0) { Console.WriteLine("FIZZ"); }
                        else if (i%num2 == 0) { Console.WriteLine("BUZZ"); }
                            else { Console.WriteLine(i);}

            }


        }
    }
}
