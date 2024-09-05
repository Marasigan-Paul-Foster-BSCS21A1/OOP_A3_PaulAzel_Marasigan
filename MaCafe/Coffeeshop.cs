class CoffeeShop
{
    private Menu menu;
    private Order order;
    private bool isRunning;

    public CoffeeShop()
    {
        menu = new Menu();
        order = new Order();
        isRunning = true;
    }

    public void Run()
    {
        while (isRunning)
        {
            DisplayMainMenu();
            int option = GetMenuOption();

            switch (option)
            {
                case 1:
                    AddMenuItem();
                    break;
                case 2:
                    ViewMenu();
                    break;
                case 3:
                    PlaceOrder();
                    break;
                case 4:
                    ViewOrder();
                    break;
                case 5:
                    CalculateTotal();
                    break;
                case 6:
                    isRunning = false;
                    Console.WriteLine("Exiting the Coffee Shop. Thank you!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine("\nWelcome to the Coffee Shop!");
        Console.WriteLine("1. Add Menu Item");
        Console.WriteLine("2. View Menu");
        Console.WriteLine("3. Place Order");
        Console.WriteLine("4. View Order");
        Console.WriteLine("5. Calculate Total");
        Console.WriteLine("6. Exit");
    }

    private int GetMenuOption()
    {
        Console.Write("Select an option: ");
        if (int.TryParse(Console.ReadLine(), out int option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return 0;
        }
    }

    private void AddMenuItem()
    {
        string name = GetItemName();
        double price = GetItemPrice();
        menu.AddMenuItem(new MenuItem(name, price));
        Console.WriteLine("Item added successfully!");
    }

    private string GetItemName()
    {
        Console.Write("Enter item name: ");
        return Console.ReadLine();
    }

    private double GetItemPrice()
    {
        Console.Write("Enter item price: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            return price;
        }
        else
        {
            Console.WriteLine("Invalid price. Please enter a valid number.");
            return GetItemPrice();
        }
    }

    private void ViewMenu()
    {
        menu.DisplayMenu();
    }

    private void PlaceOrder()
    {
        if (menu.IsMenuEmpty())
        {
            Console.WriteLine("The menu is empty. Please add items to the menu first.");
            return;
        }

        menu.DisplayMenu();
        int itemNumber = GetOrderItemNumber();

        if (menu.IsValidMenuItem(itemNumber))
        {
            order.AddToOrder(menu.GetMenuItem(itemNumber - 1));
            Console.WriteLine("Item added to order!");
        }
        else
        {
            Console.WriteLine("Invalid item number. Please try again.");
        }
    }

    private int GetOrderItemNumber()
    {
        Console.Write("Enter the item number to order: ");
        if (int.TryParse(Console.ReadLine(), out int itemNumber))
        {
            return itemNumber;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return GetOrderItemNumber();
        }
    }

    private void ViewOrder()
    {
        order.DisplayOrder();
    }

    private void CalculateTotal()
    {
        double total = order.CalculateTotal();
        Console.WriteLine($"Total Amount Payable: ${total:F2}");
    }
}