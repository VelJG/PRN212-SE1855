using Lucy_SalesManagement;

string connectionString = "server=DOANXEM;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context= new Lucy_SalesDataDataContext(connectionString);
//Get customer info when have id
int cusID = 1;
Customer cust1 = context.Customers.FirstOrDefault(c => c.CustomerID == cusID);
if(cust1 != null)
{
    Console.WriteLine(cust1.ContactName+" "+cust1.ContactName);
}

//Get all customer's order
if (cust1 != null)
{
    Console.WriteLine("Customer's Orders");
    foreach(Order od in cust1.Orders)
    {
        //decimal totalPrice=0;
        //List<Order_Detail> odd= (from o in context.Order_Details where o.OrderID==od.OrderID select o).ToList();
        //foreach(Order_Detail o in odd)
        //{
        //    totalPrice+= (o.UnitPrice * o.Quantity- o.UnitPrice * o.Quantity*(decimal)o.Discount);
        //}
        //Console.WriteLine(od.OrderID + " " + od.OrderDate.ToString("dd/MM/yyyy")+" " + totalPrice);
        decimal money = od.Order_Details.Sum(odd => odd.Quantity * odd.UnitPrice - (decimal)odd.Discount * odd.Quantity * odd.UnitPrice);

        Console.WriteLine(od.OrderID + "\t" + od.OrderDate.ToString("dd/MM/yyyy") + "\t" + money);

    }
}
// Add a price of the order