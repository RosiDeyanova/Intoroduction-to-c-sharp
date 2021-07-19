using System;
using System.Text;

namespace _22._LINQ
{
    public static class StringExtension
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int lenght)
        {
            var output = new StringBuilder();
            for (int i = index; i < lenght + index; i++)
            {
                output.Append(input[i]);
            }
            return output;
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            StringBuilder txt = new StringBuilder("ZDR KP ARE NA DISKOTE4KA");
            Console.WriteLine(txt.Substring(4, 6));

        }
    }
}
