// See https://aka.ms/new-console-template for more information

using Mission3FoodBank;

Console.WriteLine("Welcome to the Food Bank Inventory System. What would you like to do?");

string userContinues = "Y";

do
{
    Console.WriteLine("\tType 'add' to add a new food item. " +
                      "\n\tType 'delete' to delete a food item. " +
                      "\n\tType 'print' to print a list of current food items. " +
                      "\n\tType 'exit' to exit the program.");
                      
    string userInput = Console.ReadLine();
    
        if (userInput.ToLower() == "add")
        {
            //Creates new instance of a food item
            FoodItem fi = new FoodItem();
        }
        else if (userInput.ToLower() == "delete")
        {
            //displays all food items with an index, allows the user to choose one to delete, and then redisplays the updated food item list
            FoodItem.DeleteItem();
            FoodItem.PrintAllItems();
        }
        else if (userInput.ToLower() == "print")
        {
            // Display all food items
            FoodItem.PrintAllItems();
        }
        else if (userInput.ToLower() == "exit")
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0); 
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    
    Console.WriteLine("Would you like to do anything else? (Y/N)");
    userContinues = Console.ReadLine().ToUpper();
    
    if (userContinues == "N")
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}
while (userContinues == "Y");