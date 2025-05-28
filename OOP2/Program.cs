using OOP2;
using System.Text;

Console.OutputEncoding=Encoding.UTF8;
FulltimeEmployee John=new FulltimeEmployee()
{
    Id = 1, IdCard="123", Name="John Smith", DOB = new DateTime(2005, 11, 5)
            
};
Console.WriteLine("----------John Info------------");
Console.WriteLine($"Id: {John.Id}");
Console.WriteLine($"Name: {John.Name}");
Console.WriteLine($"IdCard: {John.IdCard}");
Console.WriteLine($"Date of Birth: {John.DOB.ToString("dd/MM/yyyy")}");
Console.WriteLine($"{John.Name}'s salary: {John.calSalary()}");


ParttimeEmployee Dave = new ParttimeEmployee()
{
    Id = 2,
    IdCard = "456",
    Name = "Dave Brown",
    DOB = new DateTime(2005, 11, 6)
};
Console.WriteLine("----------Dave Info------------");
Console.WriteLine($"Id: {Dave.Id}");
Console.WriteLine($"Name: {Dave.Name}");
Console.WriteLine($"IdCard: {Dave.IdCard}");
Console.WriteLine($"Date of Birth: {Dave.DOB.ToString("dd/MM/yyyy")}");
Dave.WorkHour = 10;
Console.WriteLine($"{Dave.Name}'s salary: {Dave.calSalary()}");
Console.WriteLine("-------------ToString()--------------");
Console.WriteLine(John);
Console.WriteLine(Dave);