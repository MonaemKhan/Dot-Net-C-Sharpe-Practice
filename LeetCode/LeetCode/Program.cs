using System.Linq.Expressions;
//https://leetcode.com/problems/add-two-numbers/
namespace LeetCode
{
    class program
    {
        public static void Main(string[] args)
        {
            string l1 = Console.ReadLine();
            string l2 = Console.ReadLine();
            string[] L1_text = l1.Substring(1,l1.Length-2).Split(",");
            string[] L2_text = l2.Substring(1, l2.Length - 2).Split(",");

            int max_length = Math.Max(l1.Length, l2.Length);
            int mul_fixed = 10;
            int mul = 1;
            int sum = 0;

            for (int i = 0; i < max_length; i++)
            {
                try
                {
                    sum = sumofTwoString(Convert.ToInt32(L1_text[i]), mul, sum);
                }
                catch (Exception e)
                {

                }
                try
                {
                    sum = sumofTwoString(Convert.ToInt32(L2_text[i]), mul, sum);
                }
                catch (Exception e)
                {

                }
                mul *= mul_fixed;
            }

            char[] arr = Convert.ToString(sum).ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine("["+String.Join(",", arr)+"]");
        }
        public static int sumofTwoString(int num, int multi, int sum)
        {
            sum = sum + num * multi;
            return sum;
        }
    }
}
