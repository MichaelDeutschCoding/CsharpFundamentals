using System;
using System.Collections.Generic;

namespace primes
{
    static class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {3, 5, 6, 7, 9, 11, 13};

            var primes = Find(numbers);
            
            foreach(var prime in numbers.Find(IsPrime))
            {
                Console.WriteLine(prime);
            }           
        }

        private static IEnumerable<int> Find(this IEnumerable<int> values, Func<int, bool> test)
        {
            var result = new List<int>();

            foreach (var number in values)
            {
                if (test(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static bool IsPrime(int number)
        {
            bool result = true;
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static bool IsOdd(int number)
        {
            if (number % 2 == 0)
            {
                return false;
            }

            return true;
        }
        
        private static bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}