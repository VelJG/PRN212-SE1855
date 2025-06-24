using DemoLINQToObject2;

ListProduct lp=new ListProduct();
lp.gen_products();
/*
 * Filter product price range from a to b using method syntax and query syntax 
 */
var result = lp.FilterProductByPrice(50, 200);
Console.WriteLine("Filtered by 50 - 200: ");
foreach (var item in result)
{
    Console.WriteLine(item);
}
var result2 = lp.FilterProductByPrice2(0, 50);
/*
 * Sort price desc
 */
var result3 = lp.SortProductByPriceDesc();
Console.WriteLine("Sort by price desc: ");
foreach (var item in result3)
{
    Console.WriteLine(item);
}
/*
 * Calculate total price of all product
 */
var result4= lp.TotalPrice2();
Console.WriteLine("Total price of all product: " + result4);