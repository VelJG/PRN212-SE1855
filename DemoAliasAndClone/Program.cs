using DemoAliasAndClone;

Student s1= new Student();
s1.Id = 1;
s1.Name = "John Smith";
Student s2= new Student();
s2.Id= 2;
s2.Name = "Dave Brown";
// Lúc này RAM cho 2 ô nhớ cho s1 và s2 ==> s1 đổi giá trị ko liên quan s2 vì 2 đứa nằm 2 ô nhớ khác nhau
s1 = s2;
//s1=s2 => s1 trỏ tới ô nhớ của s2
//ô nhớ của s2 h thêm s1 quản lý => alias
s2.Name = "John Cat";
Console.WriteLine(s1.Name);
//ô nhớ của s1 h ko ai giữ => Automatic Garbage Collection => Mất giá trị ban đầu của s1 

Product p1 = new Product() { Id = 1, Name = "Inwell Hoddie", Quantity = 20, Price = 8800 };
Product p2 = new Product() { Id = 2, Name = "Booty Keychain", Quantity = 20, Price = 1760 };
p1= p2;

Console.WriteLine(p1);

Product p3 = new Product() { Id = 3, Name = "Confessions Necklace", Quantity = 20, Price = 3740 };
Product p4 = new Product() { Id = 4, Name = "Novelite Plushie", Quantity = 20, Price = 3300 };
Product p5 = p3;
p3 = p4;
Product p6 = p4.clone();
Console.WriteLine("Data of Product 6:\n" + p6);
Console.WriteLine("Data of Product 4:\n" + p4);
p4.Name = " Inwell Family Mug";
Console.WriteLine("Data of Product 6:\n" + p6);
Console.WriteLine("Data of Product 4:\n" + p4);