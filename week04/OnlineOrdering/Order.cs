using System;

class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0.00;
        for (int i = 0; i < _products.Count; i++)
        {
            Product product = _products[i];
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    private double GetShippingCost()
    {
        if (_customer.USA())
        {
            return 5.0;
        }
        else
        {
            return 35.0;
        }
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        for (int i = 0; i < _products.Count; i++)
        {
            Product product = _products[i];
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}
