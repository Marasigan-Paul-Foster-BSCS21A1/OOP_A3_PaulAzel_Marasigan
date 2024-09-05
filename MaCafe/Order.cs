class Order
{
    private List<MenuItem> orderItems;

    public Order()
    {
        orderItems = new List<MenuItem>();
    }

    public void AddToOrder(MenuItem item)
    {
        orderItems.Add(item);
    }

    public void DisplayOrder()
    {
        if (orderItems.Count == 0)
        {
            Console.WriteLine("No items in the order.");
        }
        else
        {
            Console.WriteLine("Your Order:");
            foreach (var item in orderItems)
            {
                Console.WriteLine($"{item.Name} - ${item.Price:F2}");
            }
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var item in orderItems)
        {
            total += item.Price;
        }
        return total;
    }
}