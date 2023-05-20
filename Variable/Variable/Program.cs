using System;
using System.Linq;
using MyCalculator;

namespace variable
{
    class variable
    {
        static void Main(String[] args)
        {
            /*Console.WriteLine("Variable Practice");

            string name = "Monaem (String Variable)";
            Console.WriteLine(name);

            int num = 15;
            Console.WriteLine(num);

            int myNum;
            myNum = 14;
            Console.WriteLine(myNum);

            string fname = "M.A. Monaem ";
            string lname = "Khan";
            string fullName = fname + lname;
            Console.WriteLine("Hello "+fullName);

            int x, y, z;
            x = y = z = 3;
            Console.WriteLine(x+y+z);

            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello : " + name);

            Console.Write("Age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(age);
            Console.WriteLine(age + 2);

            string fname = "M.A. Monaem ";
            string lname = "khan";
            string fullName = string.Concat(fname+lname);
            Console.WriteLine("Hello >> " + fullName);
            Console.WriteLine(fullName.Length);
            Console.WriteLine(fullName.ToUpper());
            Console.WriteLine(fullName.ToLower());
            string name = $"My Full Name Is : {fname} {lname}";
            Console.WriteLine(name);
            Console.WriteLine(fullName.IndexOf("k"));
            int charpos = fullName.IndexOf("k");
           Console.WriteLine(fullName.Substring(charpos));

            string[] cars;
            cars = new string[] {"vaolvo", "bmw" , "roles_royels","fox-winer"};
            foreach(string i in cars)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Max >> "+cars.Max());
            Console.WriteLine("Min >> " + cars.Min());
            int[] num = new int[] { 1, 2, 3 ,4};
            Console.WriteLine("Sum >> " + num.Sum());*/

            //int[,] num = { { 1, 2, 3 }, { 4, 5, 6 } };
            ///*foreach (int i in num)
            //{
            //    Console.WriteLine(i);
            //}*/
            //for (int i = 0; i < num.GetLength(0); i++)
            //{
            //    for (int j = 0; j < num.GetLength(1); j++)
            //    {
            //        Console.WriteLine(num[i, j]);
            //    }
            //}

            Calculator cal = new Calculator();

            Console.WriteLine(cal.div(7, 8));
        }
    }
}


