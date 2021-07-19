using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_2
{
    public static class IEnumerableExtension
    {
        public static decimal Sum<T>(this IEnumerable<T> input)
        {
            decimal sum = 0;
            foreach (var item in input)
            {
                sum += Convert.ToDecimal(item);
            }
            return sum; 

        }

        public static decimal Average<T>(this IEnumerable<T> input)
        {
            IEnumerator iterator = input.GetEnumerator();
            int count = 0;
            while (iterator.MoveNext())
            {
                count++;
            }
            return input.Sum()/count;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
