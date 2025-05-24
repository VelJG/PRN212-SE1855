void func1(int n)
{
    n = 8;
    Console.WriteLine($"n in function have value: {n}");
}
int n = 5;
Console.WriteLine($"n before function have value: {n}");
func1(n);
Console.WriteLine($"n after function have value: {n}");

void func2(ref int n)
{
    n = 8;
    Console.WriteLine($"n in function have value: {n}");
}
Console.WriteLine("-------------------REF--------------------");
n = 5;
Console.WriteLine($"n before function have value: {n}");
func2(ref n);
Console.WriteLine($"n after function have value: {n}");
//ref: Must initialize variable before call

void func3(out int n)
{
    n = 8;
    Console.WriteLine($"n in function have value: {n}");
}
Console.WriteLine("-------------------OUT--------------------");
n = 5;
Console.WriteLine($"n before function have value: {n}");
func3(out n);
Console.WriteLine($"n after function have value: {n}");
//out: Must have new value before return






