(int,double) SumAndAvg(params int[] arr)
{
    int sum = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    double avg=sum/ arr.Length;
    return (sum, avg);
}
int[] arr = { 4, 5, 6, 7, 2, 5, 2, 6, 326, 94, 8 };
(int s, double v)= SumAndAvg(arr);
Console.WriteLine(s);
Console.WriteLine(v);
Console.WriteLine(SumAndAvg(4,5,6,7,8));