class Program
{
    public delegate int MyDelegate1(int x, int y);
    static int Add(int x, int y)
    {
        return x + y;
    }
    static int Sub(int x,int y)
    {
        return x - y;
    }
    public delegate int[] MyDelegate2(int n);
    static int[] EvenNum(int n)
    {
        List<int> list = new List<int>();
        for(int i = 2; i <= n; i += 2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }
    static int[] PrimeNumber(int n)
    {
        List<int> list= new List<int>();
        for(int i = 2; i <= n; i++)
        {
            int count = 0;
            for(int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void Main(string[] args)
    {
        MyDelegate1 d1 = new MyDelegate1(Add);
        Console.WriteLine("Addition of 8 and 5 = "+ d1(8,5));
        d1= new MyDelegate1(Sub);
        Console.WriteLine("Subtraction of 8 and 5 = " + d1(8, 5));
        MyDelegate2 d2 = new MyDelegate2(EvenNum);
        Console.WriteLine("List of even number smaller or equal to than 29: ");
        int[] a = d2(29);
        foreach(int x in a)
        {
            Console.WriteLine(x);
        }
        d2 = new MyDelegate2(PrimeNumber);
        Console.WriteLine("List of prime number smaller or equal to than 29: ");
        a = d2(29);
        foreach (int x in a)
        {
            Console.WriteLine(x);
        }

    }
}
