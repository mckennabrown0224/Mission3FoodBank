using System.Data;

namespace Mission3FoodBank
{
    public class FoodItem
    {
        // Static list to hold all instances
        public static List<FoodItem> AllItems = new List<FoodItem>();
        
        //creating all variables needed for new item creation
        public string name;
        public string category;
        public int quantity;
        private DateTime expirationDate;
        
        //constructor for new food items
        public FoodItem()
        {
            Console.WriteLine("Please answer the following questions about the new item:");
            
            //Add item name
            do
            {
                Console.WriteLine("Name (e.g., \"Canned Beans\")");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Item must have a name. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(name));

            //Add Item category
            do
            {
                Console.WriteLine("Category (e.g., \"Canned Goods\", \"Dairy\", \"Produce\")");
                category = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Item must have a category. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(category));
            
            //Add item quantity
            do
            {
                Console.WriteLine("Quantity (e.g., \"15\")");
                string quantityInput = Console.ReadLine();
                if (int.TryParse(quantityInput, out quantity) && quantity > 0)
                {
                    break; // Valid quantity
                }
                else
                {
                    Console.WriteLine("Quantity must be a positive integer. Please try again.");
                }
            } while (true);
            
            //Add item expiration date
            do
            {
                Console.WriteLine("Expiration Date (e.g., \"2021-01-01\")");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out expirationDate))
                {
                    break; // Valid date
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please use \"YYYY-MM-DD\" format and try again.");
                }
            } while (true);
            
            // Add this instance to the static list
            AllItems.Add(this);
        }
        
        // Method to display the details of a FoodItem
        public override string ToString()
        {
            return $"Name: {name}, Category: {category}, Quantity: {quantity}, Expiration: {expirationDate.ToShortDateString()}";
        }
        
        // Static method to print all items in a custom format
        public static void PrintAllItems()
        {
            Console.WriteLine("\nCurrent Food Items:");
            Console.WriteLine("------------------------------");
            
            //Checks if there are items. If none are in the inventory, a message is sent. If there are, it prints them all, along with an index.
            if (AllItems.Count == 0)
            {
                Console.WriteLine("No items in the inventory.");
            }
            else
            {
                // Sort the items by expiration date (oldest first)
                var sortedItems = AllItems.OrderBy(item => item.expirationDate).ToList();

                for (int i = 0; i < sortedItems.Count; i++)
                {
                    string expireWhen = "Expires";
                    var item = sortedItems[i];
                    
                    // Check if the expiration date is older than today's date
                    if (item.expirationDate < DateTime.Today)
                    {
                        // Set the color to red for expired items
                        Console.ForegroundColor = ConsoleColor.Red;
                        expireWhen = "EXPIRED";
                    }

                    // Print the item details
                    Console.WriteLine($"{i + 1}. {item.name} | {item.category} | Qty: {item.quantity} | {expireWhen}: {item.expirationDate:MM/dd/yyyy}");

                    // Reset the color back to normal
                    Console.ResetColor();
                }
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Total Items: {AllItems.Count}");
        }
        
        //deletion method
        public static void DeleteItem()
        {
            PrintAllItems();

            if (AllItems.Count == 0)
            {
                return;
            }

            Console.WriteLine("Enter the index (row number) of the item you want to delete:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= AllItems.Count)
            {
                var removedItem = AllItems[index - 1];
                AllItems.RemoveAt(index - 1);
                Console.WriteLine($"Removed: {removedItem.name}");
            }
            else
            {
                Console.WriteLine("Invalid selection. No item was deleted.");
            }
        }
    }
}

