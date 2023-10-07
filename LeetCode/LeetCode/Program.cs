//using System.Linq.Expressions;
////https://leetcode.com/problems/add-two-numbers/
//namespace LeetCode
//{
//    class program
//    {
//        public static void Main(string[] args)
//        {
//            string l1 = Console.ReadLine();
//            string l2 = Console.ReadLine();
//            string[] L1_text = l1.Substring(1,l1.Length-2).Split(",");
//            string[] L2_text = l2.Substring(1, l2.Length - 2).Split(",");

//            int max_length = Math.Max(l1.Length, l2.Length);
//            int mul_fixed = 10;
//            int mul = 1;
//            int sum = 0;

//            for (int i = 0; i < max_length; i++)
//            {
//                try
//                {
//                    sum = sumofTwoString(Convert.ToInt32(L1_text[i]), mul, sum);
//                }
//                catch (Exception e)
//                {

//                }
//                try
//                {
//                    sum = sumofTwoString(Convert.ToInt32(L2_text[i]), mul, sum);
//                }
//                catch (Exception e)
//                {

//                }
//                mul *= mul_fixed;
//            }

//            char[] arr = Convert.ToString(sum).ToCharArray();
//            Array.Reverse(arr);
//            Console.WriteLine("["+String.Join(",", arr)+"]");
//        }
//        public static int sumofTwoString(int num, int multi, int sum)
//        {
//            sum = sum + num * multi;
//            return sum;
//        }
//    }
//}

using System.Collections;

//string[] ops = new string[] { "5", "2", "C", "D", "+" };
////string[] ops = new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" };
//Stack<int> ok = new Stack<int>();
//for(int i = 0; i < ops.Length; i++)
//{
//    if (ops[i] == "C")
//    {
//        ok.Pop();
//    }else if (ops[i] == "D")
//    {
//        ok.Push(2*ok.Peek());
//    }else if (ops[i] == "+")
//    {
//        ok.Push(ok.ElementAt(0) + ok.ElementAt(1));
//    }else
//    {
//        ok.Push(Convert.ToInt32(ops[i]));
//    }
//}
//int sum = 0;
//foreach(int op in ok)
//{
//    sum += op;
//}
//Console.WriteLine(sum);

//IList<string> output = new List<string>();
//int[] arr = new int[] {5,4,3,2,1};
//Array.Sort(arr);
//foreach (int i in arr)
//{
//    if(i == 1)
//    {
//        output.Add("Golden Medal");
//    }else if(i == 2)
//    {
//        output.Add("Silver Medal");
//    }else if(i == 3)
//    {
//        output.Add("Bronze Medal");
//    }
//    else
//    {
//        output.Add(i+"");
//    }
//}
//foreach(var item in output)
//{
//    Console.WriteLine(item);
//}
