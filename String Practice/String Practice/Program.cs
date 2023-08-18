string date = DateTime.Now.ToString("yyyy-MM-dd");
Console.WriteLine(date);
Console.WriteLine(date.Length);
Console.WriteLine(date.Substring(0,4));
string month = date.Substring(5, 2);
Console.WriteLine(month);
Console.WriteLine();