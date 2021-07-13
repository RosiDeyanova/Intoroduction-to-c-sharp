using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chapter11 {
    public class Cat

    {

        // Field name

        private string name;

        // Field color

        private string color;



        public string Name

        {

            // Getter of the property "Name"

            get

            {

                return this.name;

            }

            // Setter of the property "Name"

            set

            {

                this.name = value;

            }

        }



        public string Color

        {

            // Getter of the property "Color"

            get

            {

                return this.color;

            }

            // Setter of the property "Color"

            set

            {

                this.color = value;

            }

        }



        // Default constructor

        public Cat()

        {

            this.name = "Unnamed";

            this.color = "gray";

        }



        // Constructor with parameters

        public Cat(string name, string color)

        {

            this.name = name;

            this.color = color;

        }



        // Method SayMiau

        public void SayMiau()

        {

            Console.WriteLine("Cat {0} said: Miauuuuuu!", name);

        }

    }
    public class Sequence

    {

        // Static field, holding the current sequence value

        private static int currentValue = 0;



        // Intentionally deny instantiation of this class

        private Sequence()

        {

        }



        // Static method for taking the next sequence value

        public static int NextValue()

        {

            currentValue++;

            return currentValue;

        }

    }
}
//Problem 7
namespace Chapter11.Examples 
{
    public class Examples 
    {
        Chapter11.Cat cat1 = new Chapter11.Cat();
    }
}

namespace _11.Objects
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //Problem 1
            Console.WriteLine(DateTime.IsLeapYear(1804));
            //Problem 2
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num = rand.Next(100);
                Console.Write((num+100) + " ");
                
            }
            Console.WriteLine();
            //Problem 3
            Console.WriteLine(DateTime.Now.DayOfWeek);
            //Problem 8
            List<Chapter11.Cat> cats = new List<Chapter11.Cat>(); //why is vector<chapter11.cat> not working then?
            int n = 1;
            for (int i = 0; i < 10; i++)
            {
                string name = "Cat" + n;
                Chapter11.Cat temp = new Chapter11.Cat();
                temp.Name = name;
                cats.Add(temp);
                n++;
            }
            for (int i = 0; i < cats.Count; i++)
            {
                cats[i].SayMiau();
            }

            //Problem 9
            string input = "43 68 9 23 318";
            string[] numbers_str =input.Split(" ");
            int[] numbers = Array.ConvertAll(numbers_str, int.Parse);
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);




        }
    }
}
