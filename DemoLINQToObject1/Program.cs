using System.Runtime.ConstrainedExecution;

Random random= new Random();
int[] a= new int[10];
for(int i=0; i<a.Length; i++)
{
    a[i] = random.Next(100);
}
//Extension Method
var ar_chan = a.Where(x => x % 2 == 0);
Console.WriteLine("Even numbers");
foreach (var item in ar_chan.ToList())
{
    Console.WriteLine(item);
}
//Query Syntax
var ar_chan2= from x in a where x%2==0 select x;
Console.WriteLine("Even numbers query");

foreach (var item in ar_chan2.ToList())
{
    Console.WriteLine(item);
}
/*
 * Increment each odd variable +2
 */
var a2=a.Where(x => x%2==1).Select(x => x+2);
Console.WriteLine("Original Data");
foreach (var item in a)
{
    Console.Write(item+"\t");
}
Console.WriteLine("\nData after filter and increment");
foreach (var item in a2)
{
    Console.Write(item + "\t");
}

/*
 * Sort asc
 */
var a3 = a.OrderBy(x => x);
var a4 = from x in a orderby x select x;
Console.WriteLine("\nSorted data");
foreach (var item in a4)
{
    Console.Write(item + "\t");
}

/*
 * Desc
 */
var a5=a.OrderByDescending(x => x);
var a6= from x in a orderby x descending select x;
/*
 * Count odd num
 */
Console.WriteLine("\nOdd numbers: "+a.Where(x=>x%2==1).Count());
int sole=(from x  in a where x%2==0 select x).Count();