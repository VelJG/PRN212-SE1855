using OOP1;

Category c1= new Category();
c1.Id = 1;
c1.Name = "John";
c1.PrintInfo();

Employee employee = new Employee();
employee.Id = 1;
employee.IdCard = "193105";
employee.Name = "John Smith";
employee.Email = "John@gmail.com";
employee.Phone = "0923234545";
employee.PrintInfo();

Employee employee2 = new Employee()
{
    Id = 2,
    Name = "Dave ManGuy",
    IdCard = "1933224",
    Email = "Dave@gmail.com",
    Phone = "095632334556"
};
Console.WriteLine("-------------Employee2--------------");
employee2.PrintInfo();

Employee employee3 = new Employee(1, "100456", "John Cat", "FoulBeast@gmail.com", "81800");
employee3.PrintInfo();
Console.WriteLine(employee3);

Employee employee4 = new Employee();
employee4.PrintInfo();

Customer customer = new Customer()
{
    Id = 123,
    Name = "Maria Hoffman",
    Email = "maria@gmail.com",
    Phone = "09571416245",
    Address = "Homeville, Towntons"
};
customer.PrintInfo();