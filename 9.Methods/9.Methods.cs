using System;

namespace _9.Methods
{
    class Program
    {
        //Problem 1
        static void ReturnName(string name) 
        {
            Console.WriteLine("Hello, "+name+"!");
        }
        //Problem 2
        static int GetMax(int a, int b) 
        {
            return Math.Max(a, b);        
        }
        //Promblem 3
        static string NameofNum(int num) 
        {
            string name;
            int n = num % 10;
            switch (n)
            {
                case 1: name = "one";break;
                case 2: name = "two"; break;
                case 3: name = "three"; break;
                case 4: name = "four"; break;
                case 5: name = "five"; break;
                case 6: name = "six"; break;
                case 7: name = "seven"; break;
                case 8: name = "eight"; break;
                case 9: name = "nine"; break;
                default: name = "null";
                    break;
            }
            return name;


        }
        //Problem 4
        static int NumofIntinArray(int n,int[] arr) {
            int num=0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (n==arr[i])
                {
                    num++;
                }
            }
            return num;        
        }
        //Problem 5
        static bool IsHronological(int n, int[] arr)
        {
            if (n==1 || n==arr.Length)
            {
                return false;
            }
            else if (arr[n]>arr[n-1]&&arr[n]<arr[n+1])
            {
                return true;
            }
            return false;
        }
        //Problem 6
        static int BiggerNum(int[] arr)
        {
            for (int i = 1; i < arr.Length-1; i++)
            {
                if (arr[i]>arr[i-1]&&arr[i]>arr[i+1])
                {
                    return i;
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            //Problem 1
            ReturnName("Ivan");
            //Problem 2
            Console.WriteLine(Math.Max(GetMax(2, 3), GetMax(3, 14)));
            //Problem 3
            Console.WriteLine(NameofNum(724));
            //Problem 4
            int[] arr = { 1, 2, 3, 2, 2, 5, 4, 2 };
            Console.WriteLine(NumofIntinArray(2,arr));
            //Problem 5
            Console.WriteLine(IsHronological(1, arr));
            //Problem 6
            Console.WriteLine(BiggerNum(arr));
        }

        //доскуча ми, минавам на следващата тема
    }
}
