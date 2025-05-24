void pic1(int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n ; j++)
        {
            if (j == 0 || j == i/2 ||j==n-1||j==n-1-(i/2))
            {
                Console.Write("*");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
 

}



    pic1(20);