using OOP3_ExtensionMethod;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int n1 = 5;
Console.WriteLine("Sum of 1 to 5= "+n1.TongTu1toiN());
int n2 = 10;
Console.WriteLine("Sum of 1 to 10= "+n2.TongTu1toiN());
Console.WriteLine("Sum of 1 to 100= " + 100.TongTu1toiN());

Console.WriteLine("10+20: "+10.Cong(20));
int[] a=new int[10];
a.TaoMang();
a.XuatMang();
Console.WriteLine("");
a.SapXepTangDan();
a.XuatMang();