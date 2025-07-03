using System;

//again I didn't learn anything new except for the decimal point formatting
//I just used what I learned from past lessons and projects

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1234 Park St", "Orlando", "FL", "USA");
        Customer customer1 = new Customer("Alex Stevinson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("T-Shirt", "T5h17t", 10.00, 5));
        order1.AddProduct(new Product("Shoes", "SHO35", 120.00, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        //I learned that I can put a :0.00 to make sure it dosn't go past 2 decimals
        //this also existed in python but looked like :.2f
        //I definetly like the C# one better because it actually makes sense
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");

        Console.WriteLine();

        Address address2 = new Address("5678 Tech Rd", "Tokyo", "Tokyo", "Japan");
        Customer customer2 = new Customer("Naisan", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "JP13", 157.25, 2));
        order2.AddProduct(new Product("Monitor", "M0N1t07", 760.00, 1));
        order2.AddProduct(new Product("PC", "9C", 2800.50, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}