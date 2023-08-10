using Quize_App_Practice;

List<Quiz_Question> Quiz1 = new List<Quiz_Question>() //this for add Multiple Question
{
    new Quiz_Question
    {
        Question = "Which of the folloing is not allowed in c# as access modifier ?",
        QuestionOptions = new List<string>()
        {
            "Friend","Public","Private"
        },
        RightAnswer="Friend",
        Mark = 30 
    },
    new Quiz_Question
    {
        Question = "Which of the folloing method is an entry point in c# ?",
        QuestionOptions = new List<string>()
        {
            "Main","Final"
        },
        RightAnswer="Main",
        Mark = 20
    },
    new Quiz_Question
    {
        Question = "Which of the folloing are value type in c# ?",
        QuestionOptions = new List<string>()
        {
            "Int","String","Ex"
        },
        RightAnswer="Int",
        Mark = 25
    },
    new Quiz_Question
    {
        Question = "Which of the folloing is a refference type in c#.net ?",
        QuestionOptions = new List<string>()
        {
            "String","Long"
        },
        RightAnswer="String",
        Mark = 15
    },
    new Quiz_Question
    {
        Question = "Enum is a ?",
        QuestionOptions = new List<string>()
        {
           "Special Class",
        "Method","Array"
        },
        RightAnswer="Special Class",
        Mark = 10
    }
};

Console.Write("Enter Your Name : ");
List<User> user1 = new List<User>()
{
    new User()
    {
        UserName = Console.ReadLine(),
        Quiz = Quiz1,
    }
};

int ans;
int i = 1;
int sum = 0;
int wrong_ans = 0;
int right_ans = 0;

foreach (var data in user1[0].Quiz)
{
    Console.WriteLine($"Question-{i}: {data.Question}");

    int j = 1;
    foreach (var option in data.QuestionOptions)
    {
        Console.Write($"{j}) {option}\t");
        j = j + 1;
    }

    Console.WriteLine("\nGive answer according to your option number, or else it consider as a wrong answer");

    Console.Write("Give Answer : ");
    ans = Convert.ToInt32(Console.ReadLine());
    try
    {
        data.YourAnswer = data.QuestionOptions[ans - 1];
    }
    catch (Exception ex)
    {
        data.YourAnswer = "Wrong Answer";
    }

    if (data.YourAnswer == data.RightAnswer)
    {
        sum = sum + data.Mark;
        right_ans++;
    }
    else
    {
        wrong_ans++;
    }
    Console.WriteLine();
    i = i + 1;
}

user1[0].TotalMark = sum;
user1[0].TotalRightAnswer = right_ans;
user1[0].TotalWrongAnswer = wrong_ans;

Console.WriteLine("\nExam Finished!!\nYour Evaluation\n");

foreach (var user in user1)
{
    Console.WriteLine("This Answe Is Submitted By : Mr. " + user.UserName);
    Console.WriteLine();
    i = 1;
    foreach (var data in user.Quiz)
    {
        Console.WriteLine($"Question-{i}: {data.Question}");
        int j = 1;
        foreach (var option in data.QuestionOptions)
        {
            Console.Write($"{j}) {option}\t");
            j = j + 1;
        }
        Console.WriteLine($"\nYour Answer Is : {data.YourAnswer}");
        Console.WriteLine($"Right Answer Is : {data.RightAnswer}");
        Console.WriteLine($"Mark Contain: {data.Mark}");
        if (data.YourAnswer == data.RightAnswer)
        {
            Console.WriteLine("Status : Right Answer");
            Console.WriteLine($"Mark Get: {data.Mark}");
        }
        else
        {
            Console.WriteLine("Status : Wrong Answer");
            Console.WriteLine($"Mark Get: {0}");
        }
        Console.WriteLine();
        i = i + 1;
    }
    Console.WriteLine($"Total Mark Is : {user.TotalMark}");
    Console.WriteLine($"\nTotal Right Answer : {user.TotalRightAnswer}");
    Console.WriteLine($"\nTotal Wrong Answer : {user.TotalWrongAnswer}");
}


//Console.WriteLine(Quiz1[0].QuestionOptions[1]);

//int ans;
//int i = 1;
//foreach (var data in Quiz1)
//{
//    Console.WriteLine($"Question-{i}: {data.Question}");

//    int j = 1;
//    foreach (var option in data.QuestionOptions)
//    {
//        Console.Write($"{j}) {option}\t");
//        j = j + 1;
//    }

//    Console.WriteLine("\nGive answer according to your option number, or else it consider as a wrong answer");

//    Console.Write("Give Answer : ");
//    ans = Convert.ToInt32(Console.ReadLine());
//    //if (ans == 1)
//    //{
//    //    //Console.WriteLine(data.QuestionOptions[0]);
//    //    data.YourAnswer = data.QuestionOptions[0];
//    //}
//    //else if (ans == 2)
//    //{
//    //    //Console.WriteLine(data.QuestionOptions[1]);
//    //    data.YourAnswer = data.QuestionOptions[1];
//    //}
//    //else
//    //{
//    //    data.YourAnswer = "Wrong Answer";
//    //}
//    try
//    {
//        data.YourAnswer = data.QuestionOptions[ans - 1];
//    }catch(Exception ex)
//    {
//        data.YourAnswer = "Wrong Answer";
//    }
//    Console.WriteLine();
//    i = i + 1;
//}
////Console.WriteLine(Quiz1[0].YourAnswer);
////Console.WriteLine(Quiz1[0].RightAnswer);
////Console.WriteLine(Quiz1[0].Mark);

//int sum = 0;
//int wrong_ans = 0;
//int right_ans = 0;
//foreach (var data in Quiz1)
//{
//    if (data.YourAnswer == data.RightAnswer)
//    {
//        sum = sum + data.Mark;
//        right_ans++;
//    }
//    else
//    {
//        wrong_ans++;
//    }
//}

////i = 1;
////int wrong_ans = 0;
////int right_ans = 0;
////foreach (var data in Quiz1)
////{
////    Console.WriteLine($"Question-{i}: {data.Question}");
////    int j = 1;
////    foreach (var option in data.QuestionOptions)
////    {
////        Console.Write($"{j}) {option}\t");
////        j = j + 1;
////    }
////    Console.WriteLine($"\nYour Answer Is : {data.YourAnswer}");
////    Console.WriteLine($"Right Answer Is : {data.RightAnswer}");
////    Console.WriteLine($"Mark Contain: {data.Mark}");
////    if (data.YourAnswer == data.RightAnswer)
////    {
////        right_ans++;
////        Console.WriteLine("Status : Right Answer");
////        Console.WriteLine($"Mark Get: {data.Mark}");
////    }
////    else
////    {
////        wrong_ans++;
////        Console.WriteLine("Status : Wrong Answer");
////        Console.WriteLine($"Mark Get: {0}");
////    }
////    Console.WriteLine();
////    i = i + 1;
////}
//Console.Write("Enter Your Name : ");
//List<User> User1 = new List<User>()
//{
//    new User
//    {
//        UserName = Console.ReadLine(),
//        Quiz = Quiz1,
//        TotalMark = sum,
//        TotalRightAnswer = right_ans,
//        TotalWrongAnswer = wrong_ans
//    }
//};

//Console.WriteLine("\nExam Finished!!\nYour Evaluation\n");
//foreach (var user in User1)
//{
//    Console.WriteLine("This Answe Is Submitted By : Mr. "+user.UserName);
//    Console.WriteLine();
//    i = 1;
//    foreach (var data in user.Quiz)
//    {
//        Console.WriteLine($"Question-{i}: {data.Question}");
//        int j = 1;
//        foreach (var option in data.QuestionOptions)
//        {
//            Console.Write($"{j}) {option}\t");
//            j = j + 1;
//        }
//        Console.WriteLine($"\nYour Answer Is : {data.YourAnswer}");
//        Console.WriteLine($"Right Answer Is : {data.RightAnswer}");
//        Console.WriteLine($"Mark Contain: {data.Mark}");
//        if (data.YourAnswer == data.RightAnswer)
//        {
//            right_ans++;
//            Console.WriteLine("Status : Right Answer");
//            Console.WriteLine($"Mark Get: {data.Mark}");
//        }
//        else
//        {
//            wrong_ans++;
//            Console.WriteLine("Status : Wrong Answer");
//            Console.WriteLine($"Mark Get: {0}");
//        }
//        Console.WriteLine();
//        i = i + 1;
//    }
//    Console.WriteLine($"Total Mark Is : {user.TotalMark}");
//    Console.WriteLine($"\nTotal Right Answer : {user.TotalRightAnswer}");
//    Console.WriteLine($"\nTotal Wrong Answer : {user.TotalWrongAnswer}");
//}