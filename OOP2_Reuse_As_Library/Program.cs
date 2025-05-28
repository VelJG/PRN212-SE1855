//Cài hàm tính tuổi vào Employee và ko thay đổi OOP2
using OOP2;
using OOP2_Reuse_As_Library;

FulltimeEmployee e1= new FulltimeEmployee();
e1.Id = 3;
e1.Name = "David";
e1.IdCard = "789";
e1.DOB = new DateTime(2005,12,5);
Console.WriteLine("------------------E1 Info-------------");
Console.WriteLine(e1);
Console.WriteLine("Age: " + e1.CalAge());