using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Console.WriteLine("");

        // Customer 1 (USA)
        Address a1 = new Address("My Street", "New York", "NY", "USA");
        Customer c1 = new Customer("Ugochi Ebere", a1);
        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Laptop", "L001", 850, 2));
        o1.AddProduct(new Product("Tractor", "Tk003", 25, 2));
        o1.AddProduct(new Product("Ink", "INK074", 25, 2));
        // o1.AddProduct(new Product("Phone, "iphonex", 850, 2));

        // Customer 2 (Non-USA)
        Address a2 = new Address("45 Street", "Nigeria", "NGi", "NG");
        Customer c2 = new Customer("Emeka Ubani", a2);
        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Headphones", "H008", 50, 1));
        o2.AddProduct(new Product("Candy", "KC0", 20, 7));


        Address a3 = new Address("GZI", "Aba", "NG", "USA");
        Customer c3 = new Customer("Junior Ogolo", a3);
        Order o3 = new Order(c3);
        o3.AddProduct(new Product("Air Conditioner", "AC01", 850, 2));
        o3.AddProduct(new Product("Diepers", "DIP003", 100, 30));
        o3.AddProduct(new Product("Pen", "PEN011", 50, 13));

        List<Order> orders = new List<Order> { o1, o2, o3 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost()}\n");
            Console.WriteLine(new string('-', 40));
        }
    }
}