using System.Runtime.InteropServices;

void swap(ref int a, ref int b)
{
    int temp = a; 
    a=b; 
    b=temp;
}
void sortArray(params int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] >= arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
        }
    }
}

void sortArrayWhile(params int[] arr)
{
    int i = 0;
    
    while (i < arr.Length)
    {
        int j = i+1;
        while (j < arr.Length) {
            if (arr[i] >= arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        }
        i++;

    }
}

void sortArrayDoWhile(params int[] arr)
{
    int i = 0;

    do
    {
        int j = i+1;
        do
        {
            if (arr[i] >= arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
            j++;
        } while (j < arr.Length);
        i++;
    } while (i < arr.Length-1); 
}
void createArray(int[] arr)
{
    Random rd = new Random();
    for(int i = 0; i < arr.Length; i++)
    {
        arr[i] = rd.Next(100);
    }
}
void printArray(int[] arr)
{
    foreach(int i in arr)
    {
        Console.Write(i+" ");
    }
}

int[] a = new int[10];
createArray(a);
Console.WriteLine("Array before sort");
printArray(a);
//Console.WriteLine("\nArray after sort");
//sortArray(a);
//printArray(a);
Console.WriteLine("\nArray after sortWhile");
sortArrayDoWhile(a);
printArray(a);

