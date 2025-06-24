using DemoLINQToSQL;
using System.Security.Cryptography;

string connectionString = "server=DOANXEM;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context=new MyStoreDataContext(connectionString);
//CRUD: GetAll
var cateList= context.Categories.ToList();
Console.WriteLine("Category List");
foreach(var cate in cateList)
{
    Console.WriteLine(cate.CategoryID+" "+cate.CategoryName);
}
//Use query syntax to filter Product
var proList = from p in context.Products select p;
Console.WriteLine("Product List");
foreach(  var pro in proList)
{
    Console.WriteLine(pro.ProductID +" "+pro.ProductName+ " "+ pro.UnitPrice);
}
//Find category when have category id=3
int catId = 3;
Category category = context.Categories.FirstOrDefault(x => x.CategoryID == catId);
if(category== null)
{
    Console.WriteLine("Category not found");
}
else
{
    Console.WriteLine("Category found");
    Console.WriteLine(category.CategoryID + " " + category.CategoryName);
}
// Get the top 3 product with highest price
var topPriceProduct =context.Products.OrderByDescending(p => p.UnitPrice).Take(3);
Console.WriteLine("Top 3 products with highest price");
foreach( var p in topPriceProduct)
{
    Console.WriteLine(p.ProductID + " " + p.ProductName + " "+p.UnitPrice);
}
//Add new Category
//Category c1 = new Category();
//c1.CategoryName = "Merch";
//context.Categories.InsertOnSubmit(c1);
//context.SubmitChanges();

//Find and Edit Category Name
//Category c13 = context.Categories.FirstOrDefault(c => c.CategoryID == 6);
//if (c13 != null)
//{
//    c13.CategoryName = "AAAAAAAAA";
//    context.SubmitChanges();
//}
//else
//{
//    Console.WriteLine("Category not found");
//}
//Delete
//Category c9 = context.Categories.FirstOrDefault(c => c.CategoryID == 9);
//if (c9 != null)
//{
//    context.Categories.DeleteOnSubmit(c9);
//    context.SubmitChanges();
//}
//else
//{
//    Console.WriteLine("Category not found");
//}
//Delete Category with no product
//var cateWithEmptyProduct=context.Categories.Where(c=>c.Products.Count()==0).ToList();
//context.Categories.DeleteAllOnSubmit(cateWithEmptyProduct);
//context.SubmitChanges();

//Add many Category
List<Category> newCateList= new List<Category>();
newCateList.Add(new Category() { CategoryName = "F" });
newCateList.Add(new Category() { CategoryName = "T" });
newCateList.Add(new Category() { CategoryName = "U" });
newCateList.Add(new Category() { CategoryName = "I" });
newCateList.Add(new Category() { CategoryName = "O" });
context.Categories.InsertAllOnSubmit(newCateList);
context.SubmitChanges();