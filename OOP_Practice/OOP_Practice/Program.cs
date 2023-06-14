
using OOP_Practice;

List<Course> co = new List<Course>()
{
    new Course{CourseId="CSE-1101",CourseTitle="Computer Fundamental",CourseDuration="45 Hours",CourseCradite=3.00},
    new Course{CourseId="CSE-1102",CourseTitle="C Programming",CourseDuration="45 Hours",CourseCradite=3.00},
};

List<Faculty> fa = new List<Faculty>()
{
    new Faculty{Name="Dhiman Sarma",Phone="019xxxxx",Email="Dhiman@mail.com",Address="Cox-Bazar",JoiningDate=Convert.ToDateTime("1/11/2017"),CourseId="CSE-1101"},
    new Faculty{Name="Juel Sikder",Phone="017xxxxx",Email="juel@mail.com",Address="Chittagong",JoiningDate=Convert.ToDateTime("1/11/2017"),CourseId="CSE-1102"}
};

List<Student> sa = new List<Student>()
{
    new Student{Name="Sama",Id="2016-13-43",Phone="015xxxxx",Email="sama@mail.com",Address="Kurigram",CourseTitle="Computer Fundamental"},
    new Student{Name="mong",Id="2016-13-40",Phone="016xxxxx",Email="mong@mail.com",Address="Bandarban",CourseTitle="C Programming"},
    new Student{Name="prosen",Id="2016-13-50",Phone="018xxxxx",Email="prosen@mail.com",Address="Rangamati",CourseTitle="Computer Fundamental"},
    new Student{Name="saharab",Id="2016-13-21",Phone="019xxxxx",Email="saharab@mail.com",Address="Bandarban",CourseTitle="C Programming"}
};


//var teacher = from f in fa
//              select f;
//foreach (var item in teacher)
//{
//    Console.WriteLine($"Name : {item.Name}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}");
//    Console.WriteLine($"Address : {item.Address}");
//    Console.WriteLine($"JoinDate : {item.JoiningDate}\n");
//}

////create new student by input
//Console.Write("Your Name : ");
//string name = Console.ReadLine();
//Console.Write("Your ID : ");
//string id = Console.ReadLine();
//Console.Write("Your Phone : ");
//string phone = Console.ReadLine();
//Console.Write("Your Email : ");
//string email = Console.ReadLine();
//Console.Write("Your Address : ");
//string address = Console.ReadLine();
//Console.Write("Your Course Title : ");
//string course_title = Console.ReadLine();

//sa.Add( new Student
//{
//    Name=name,Id=id,Phone=phone,Email=email,Address=address,CourseTitle=course_title
//});

//var student = from s in sa
//              select s;
//foreach (var item in student)
//{
//    Console.WriteLine($"\nName : {item.Name}");
//    Console.WriteLine($"ID : {item.Id}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}");
//    Console.WriteLine($"Address : {item.Address}");
//    Console.WriteLine($"Course Title : {item.CourseTitle}\n");
//}


////show student course and faculty details
//var course_detail = from s in sa
//                    join c in co on s.CourseTitle equals c.CourseTitle
//                    join f in fa on c.CourseId equals f.CourseId
//                    select new { s.Name,s.Id,c.CourseId,c.CourseTitle,c.CourseCradite,c.CourseDuration,fname=f.Name,f.Phone,f.Email};

//foreach (var item in course_detail)
//{
//    Console.WriteLine($"Student Name : {item.Name}");
//    Console.WriteLine($"Student ID : {item.Id}");
//    Console.WriteLine($"===== Course Details =====");
//    Console.WriteLine($"Couse Code : {item.CourseId}");
//    Console.WriteLine($"Course Title : {item.CourseTitle}");
//    Console.WriteLine($"Course Cradite : {item.CourseCradite}");
//    Console.WriteLine($"Course Duration : {item.CourseDuration}");
//    Console.WriteLine($"===== Course Teacher Details =====");
//    Console.WriteLine($"Name : {item.fname}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}\n\n");

//}


////show selected student course and faculty details
//Console.Write("Enter Your Student ID : ");
//string id_input = Console.ReadLine();

//var course_detail = from s in sa
//                    join c in co on s.CourseTitle equals c.CourseTitle
//                    join f in fa on c.CourseId equals f.CourseId
//                    where s.Id== id_input
//                    select new { s.Name, s.Id, c.CourseId, c.CourseTitle, c.CourseCradite, c.CourseDuration, fname = f.Name, f.Phone, f.Email };

//foreach (var item in course_detail)
//{
//    Console.WriteLine($"Student Name : {item.Name}");
//    Console.WriteLine($"Student ID : {item.Id}");
//    Console.WriteLine($"===== Course Details =====");
//    Console.WriteLine($"Couse Code : {item.CourseId}");
//    Console.WriteLine($"Course Title : {item.CourseTitle}");
//    Console.WriteLine($"Course Cradite : {item.CourseCradite}");
//    Console.WriteLine($"Course Duration : {item.CourseDuration}");
//    Console.WriteLine($"===== Course Teacher Details =====");
//    Console.WriteLine($"Name : {item.fname}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}\n\n");
//}


////student info update

//var student = from s in sa
//              where s.Id == "2016-13-43"
//              select s;
//foreach (var item in student)
//{
//    Console.WriteLine($"=====Before Udate=====\nName : {item.Name}");
//    Console.WriteLine($"ID : {item.Id}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}");
//    Console.WriteLine($"Address : {item.Address}");
//    Console.WriteLine($"Course Title : {item.CourseTitle}\n");
//}
//foreach (var item in student)
//{
//    item.Name = "Abu Sama"; // -----(next)----use switch case to update a specific information
//}
//foreach (var item in student)
//{
//    Console.WriteLine($"=====After Udate=====\nName : {item.Name}");
//    Console.WriteLine($"ID : {item.Id}");
//    Console.WriteLine($"Phone : {item.Phone}");
//    Console.WriteLine($"Email : {item.Email}");
//    Console.WriteLine($"Address : {item.Address}");
//    Console.WriteLine($"Course Title : {item.CourseTitle}\n");
//}


//remove student details

Console.WriteLine("=====Before Remove=====");
var stu = from s in sa
          select s;
foreach (var item in stu)
{
    Console.WriteLine($"Name : {item.Name}");
    //Console.WriteLine($"ID : {item.Id}");
    //Console.WriteLine($"Phone : {item.Phone}");
    //Console.WriteLine($"Email : {item.Email}");
    //Console.WriteLine($"Address : {item.Address}");
    //Console.WriteLine($"Course Title : {item.CourseTitle}\n");
}

int index = 0;
for (int i = 0;i<sa.Count;i++)
{
    if (sa[i].Id == "2016-13-50")
    {
        index = i; break;
    }
}

sa.RemoveAt(index);

Console.WriteLine("=====After Remove=====");
stu = from s in sa
      select s;
foreach (var item in stu)
{
    Console.WriteLine($"Name : {item.Name}");
    //Console.WriteLine($"ID : {item.Id}");
    //Console.WriteLine($"Phone : {item.Phone}");
    //Console.WriteLine($"Email : {item.Email}");
    //Console.WriteLine($"Address : {item.Address}");
    //Console.WriteLine($"Course Title : {item.CourseTitle}\n");
}