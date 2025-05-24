int sum(params int[] arr)
{
    int s = 0;
    foreach (int i in arr)
    {
        s += i;
      
    }  return s;
}
Console.WriteLine(sum(0));
Console.WriteLine(sum(1,4,5,6,3,5,3,7));
Console.WriteLine(sum(675,56765,6577,56));