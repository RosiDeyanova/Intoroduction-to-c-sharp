using System;
using System.Text;

namespace Problem_7
{
    public static class StringExtension
    {
        public static string MakeWordsUppercase(this string input)
        {
            StringBuilder txt = new StringBuilder(input.ToLower());
            for (int i = 0; i < txt.Length; i++)
            {
                if (i == 0 || txt[i - 1].ToString() == " ")
                {
                    txt[i] = Char.ToUpper(txt[i]);
                }
               
            }
            return txt.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringExtension.MakeWordsUppercase("this iS a Sample sentence."));
        }
    }
}
