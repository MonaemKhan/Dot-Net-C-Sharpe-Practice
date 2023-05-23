
using OOP;

//List<Student> st = new List<Student>();

//st.Add(new Student
//{
//    Id = 1,
//    Name = "Monaem Khan",
//    Address = "Chapai",
//    Phone = "01303",
//    Email = "mona@gmail.com",
//    Age = 25,
//    CourseId = "CSE-1101"
//});

//st.Add(new Student
//{
//    Id = 2,
//    Name = "Sama",
//    Address = "Kurigram",
//    Phone = "01505",
//    Email = "sama@gmail.com",
//    Age = 25,
//    CourseId = "CSE-1102"
//});

//foreach (var student in st)
//{
//    Console.WriteLine(student.Id);
//    Console.WriteLine(student.Name);
//    Console.WriteLine(student.Address);
//    Console.WriteLine(student.Phone);
//    Console.WriteLine(student.Email);
//    Console.WriteLine(student.Age);
//    Console.WriteLine(student.CourseId);
//    Console.WriteLine("=====================");
//}

//List<Course> co = new List<Course>()
//{
//    new Course
//    {
//        CourseID = "CSE-1101",
//        CourseName = "Computer Fundamental",
//        Fees = 600,
//        Duration = "45H"
//    },
//    new Course
//    {
//        CourseID = "CSE-1102",
//        CourseName = "Structural Programming",
//        Fees = 600,
//        Duration = "45H"
//    }
//};

//foreach (var course in co)
//{
//    Console.WriteLine(course.CourseID);
//    Console.WriteLine(course.CourseName);
//    Console.WriteLine(course.Fees);
//    Console.WriteLine(course.Duration);
//    Console.WriteLine("=====================");
//}


interface_ inf = new interface_();

Console.WriteLine(inf.add(12, 12));
Console.WriteLine(inf.sub(12, 3));

Class1 class1 = new Class1();

Console.WriteLine(class1.total());