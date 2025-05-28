
/* Sử dụng Generic List để quản lý nhân sự
 * Làm đủ CRUD
 * Create: Thêm
 * Read: Đọc, truy vấn
 * Update: Chỉnh
 * Delete: Xóa
 */

/*
 * Dùng list tạo 5 Employee, 4 Fulltime 1 Parttime
 */
using OOP2;

List<Employee> employees = new List<Employee>();
FulltimeEmployee e1= new FulltimeEmployee();
e1.Id = 1;
e1.Name = "John";
e1.IdCard = "123";
e1.DOB = new DateTime(2005, 12, 7);
employees.Add(e1);

FulltimeEmployee e2 = new FulltimeEmployee();
e2.Id = 2;
e2.Name = "Dave";
e2.IdCard = "1234";
e2.DOB = new DateTime(2005, 5, 2);
employees.Add(e2);

FulltimeEmployee e3 = new FulltimeEmployee();
e3.Id = 3;
e3.Name = "David";
e3.IdCard = "43534";
e3.DOB = new DateTime(2005, 2, 24);
employees.Add(e3);

FulltimeEmployee e4 = new FulltimeEmployee();
e4.Id = 4;
e4.Name = "Johnny";
e4.IdCard = "4367876";
e4.DOB = new DateTime(2005, 1, 4);
employees.Add(e4);

ParttimeEmployee e5= new ParttimeEmployee();
e5.Id = 5;
e5.Name = "Gus";
e5.IdCard = "134";
e5.DOB = new DateTime(2005,7,7);
e5.WorkHour = 8;
employees.Add(e5);

//Cau2: Read all employee
Console.WriteLine("----------------Employee List, First Method---------------");
employees.ForEach(e => Console.WriteLine(e));

Console.WriteLine("----------------Employee List, Second Method---------------");
foreach (var item in employees)
{
    Console.WriteLine(item);
    
}
//Cau 3: Filter Fulltime Employee, calculate total salary
List<FulltimeEmployee> fulltimeEmployees = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("----------------Fulltime Employee List---------------");

foreach (var item in fulltimeEmployees)
{
    Console.WriteLine(item);
}

List<FulltimeEmployee> fulltimeEmployees1 = new List<FulltimeEmployee>();
Console.WriteLine("----------------Fulltime Employee List 2---------------");
foreach (var item in employees)
{
    if(item is FulltimeEmployee)
    {
        fulltimeEmployees1.Add(item as FulltimeEmployee);
    }
}
foreach(var item in fulltimeEmployees1)
{
    Console.WriteLine(item);
}
double sum = fulltimeEmployees.Sum(e => e.calSalary());
Console.WriteLine("Total FullTime Employee Salary: " + sum);
//Cau4: Sort employee by DOB
for(int i = 0; i < employees.Count; i++)
{
    for(int j=i+1; j<employees.Count; j++)
    {
        Employee ei = employees[i];
        Employee ej = employees[j];
        if (ei.DOB > ej.DOB)
        {
            employees[i] = ej;
            employees[j] = ei;
        }
    }
}
Console.WriteLine("Sort Employee");
foreach (var item in employees)
{
    Console.WriteLine(item);

}
//Question 4: Edit employee infomation
Console.WriteLine("-----------------Info of the first employee-----------------");
Console.WriteLine(employees[0]);
employees[0].Name = "Johnny Smith";
Console.WriteLine("-------------------Info after edit-----------------");
Console.WriteLine(employees[0]);

//Question 5: Delete employee
employees.Remove(employees[1]);
Console.WriteLine("------------------Employee List after deleting---------------");
foreach (var item in employees)
{
    Console.WriteLine(item);
}