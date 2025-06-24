using OOP5_Dictionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1= new Category();
c1.Id = 1;
c1.Name = "Soda";

Product p1= new Product();
p1.Id = 1;
p1.Name = "Pepsi";
p1.Quantity = 10;
p1.Price = 9;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Coca";
p2.Quantity = 20;
p2.Price = 17;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "Mirinda";
p3.Quantity = 30;
p3.Price = 12;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "Dr.Pepper";
p4.Quantity = 15;
p4.Price = 15;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "Sting";
p5.Quantity = 25;
p5.Price = 15;
c1.AddProduct(p5);

Console.WriteLine("------------Show all Product-------------");
c1.PrintAllProduct();

Console.WriteLine("------------Filter Product---------------");
Dictionary<int, Product> filters = c1.FilterProductByPrice(12, 20);
foreach(KeyValuePair<int, Product> filter in filters)
{
    Product p=filter.Value;
    Console.WriteLine(p);
}

Console.WriteLine("------------Sort Product By Price Ascending-------------");
Dictionary<int, Product> sortResult = c1.SortProductByPriceAsc();
foreach(KeyValuePair <int, Product> sort in sortResult)
{
    Product p=sort.Value;
    Console.WriteLine(p);
}

Console.WriteLine("------------Sort Product By Price Asc and Quantity Desc-----------");
Dictionary<int, Product> complexSort = c1.ComplexSort();
foreach(KeyValuePair<int,Product> sort in complexSort)
{
    Product p=sort.Value;
    Console.WriteLine(p);
}


p1.Name = "Pepsi Zero";
p1.Quantity = 35;
p1.Price = 13;
c1.UpdateProduct(p1);
Console.WriteLine("---------Products after Update---------------");
c1.PrintAllProduct();


int id = 2;
bool del=c1.RemoveProduct(id);
if (del)
{
    Console.WriteLine($"Product Id: {id} has been removed");
    Console.WriteLine("------------Products after Remove-----------");
    c1.PrintAllProduct();
}
else
{
    Console.WriteLine($"Product Id: {id} not found");
}
Category c2 = new Category();
c2.Id = 2;
c2.Name = "Beer";
c2.AddProduct(new Product(){Id = 6,Name = "333",Quantity = 10,Price = 6});
c2.AddProduct(new Product() { Id = 7, Name = "Tiger", Quantity = 45, Price = 9 });

LinkedList<Category> ss = new LinkedList<Category>();
ss.AddLast(c1);
ss.AddLast(c2);
Console.WriteLine("------------All data by category----------");
foreach (Category c in ss)
{
    Console.WriteLine("--"+c.Name+"--");
    Console.WriteLine("****************");
    c.PrintAllProduct();
    Console.WriteLine("****************");
}

