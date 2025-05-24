// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Phương trình bậc 1");
Console.WriteLine("Hệ số a: ");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("Hệ số b: ");
double b = double.Parse(Console.ReadLine());
if (a == 0)
{
    if (b == 0)
    {
        Console.WriteLine("Phương trình có vô số nghiệm");
    }
    else
    {
        Console.WriteLine("Nuhuh, vô nghiệm");
    }
}
else
{
    double x = -b / a;
    Console.WriteLine("Phương trình có nghiệm x = {0}", x);
}
Console.ReadLine();