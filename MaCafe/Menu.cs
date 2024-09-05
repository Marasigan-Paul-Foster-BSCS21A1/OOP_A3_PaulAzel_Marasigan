class Menu
{
    private List<MenuItem> menuItems;

    public Menu()
    {
        menuItems = new List<MenuItem>();
    }

    public void AddMenuItem(MenuItem item)
    {
        menuItems.Add(item);
    }

    public void DisplayMenu()
    {
        if (menuItems.Count == 0)
        {
            Console.WriteLine("The menu is currently empty.");
        }
        else
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i].Name} - ${menuItems[i].Price:F2}");
            }
        }
    }

    public bool IsMenuEmpty()
    {
        return menuItems.Count == 0;
    }

    public MenuItem GetMenuItem(int index)
    {
        return menuItems[index];
    }

    public bool IsValidMenuItem(int itemNumber)
    {
        return itemNumber > 0 && itemNumber <= menuItems.Count;
    }
}