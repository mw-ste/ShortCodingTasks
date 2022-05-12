using System;

namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static void Run(IEnumerable<int> values){
            foreach (var value in values)
            {
                if(value % 3 == 0)
                {
                    Console.Write("Fizz");
                }

                Console.Write("\n");
            }
        }
    }
}