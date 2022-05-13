using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static void Run(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                var fizz = value % 3 == 0;
                var buzz = value % 5 == 0;

                if(fizz)
                {
                    Console.Write("Fizz");
                }

                if(buzz)
                {
                    Console.Write("Buzz");
                }

                if(!(fizz || buzz))
                {
                    Console.Write(value);
                }

                Console.Write("\n");
            }
        }
    }
}