/*
 * Nhập 1 số >=0 , nhập sai yêu cầu nhập cho đến khi đúng
 * Đúng thì tính giai thừa
 */
using System.Security.Cryptography.X509Certificates;

int n = -1;
while (n < 0)
{
    Console.WriteLine("Please enter a positive number: ");
    string input=Console.ReadLine();
    if (int.TryParse(input, out n) == true)
    {// In here n is a int but can be <0
        if (n >= 0)
        {
            Console.WriteLine("Yayyyy");
            break;
        }
        else
        {
            Console.WriteLine("You dumb");
        }

    }
    else
    {
        Console.WriteLine("You dumb");
    }
}
int gt = 1;
for(int i = 1; i <= n; i++)
{
    gt = gt * i;
}
Console.WriteLine($"{n}!={gt}");
