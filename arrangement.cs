using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>();

        Console.Write("Enter the number of orders: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Order order = new Order();

            Console.WriteLine($"\nEnter details for Order {i}:");

            Console.Write("Order ID: ");
            order.OrderId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Customer Name: ");
            order.CustomerName = Console.ReadLine();

            Console.Write("Order Date (yyyy-mm-dd): ");
            order.OrderDate = Convert.ToDateTime(Console.ReadLine());

            orders.Add(order);
        }

        Console.WriteLine("\n===== Orders from Oldest to Newest =====");

        var oldestToNewest = orders.OrderBy(o => o.OrderDate);

        foreach (var order in oldestToNewest)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Date: {order.OrderDate.ToShortDateString()}");
        }

        Console.WriteLine("\n===== Orders from Newest to Oldest =====");

        var newestToOldest = orders.OrderByDescending(o => o.OrderDate);

        foreach (var order in newestToOldest)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Date: {order.OrderDate.ToShortDateString()}");
        }
    }
}