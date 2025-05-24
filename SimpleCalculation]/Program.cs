Console.OutputEncoding = System.Text.Encoding.UTF8;
void doCalculate(double a, double b, string op)
{
    switch (op)
    {
        case "+":
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
            break;
        case "-":
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);

            break;
        case "*":
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);

            break;
        case "/":
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by 0");
            }
            else
            {
                Console.WriteLine("{0} / {1} = {2}", a, b, a / b);

            }
            break;
        default:
            Console.WriteLine("Nuh uh");
            break;
    }
}

Console.WriteLine("Simple calculation");
Console.WriteLine("Enter a: ");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("Enter b: ");
double b = double.Parse(Console.ReadLine());
Console.WriteLine("Enter operator: (+,-,*,/)");
string op = Console.ReadLine();
doCalculate(a, b, op);
Console.WriteLine("\nGETOUT");