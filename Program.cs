using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace shoppingList
{
    class Program
    {
        static List<Item> itemList = new List<Item>();
        static void Main(string[] args)
        {
            bool go = true;
            string filePath = "./list.csv";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] arr = line.Split(',');
                    itemList.Add(new Item(arr[0],arr[1],arr[2]));
                }
            }
            while(go)
            {
                int inputNum;
                while(true)
                {
                    Console.WriteLine("1. Add new Item\n2. List All Items\n3. Show Total Cost\n4. Clear List\n5. Save List\n6. Exit\nEnter the number for the action you wish to complete");
                    string input = Console.ReadLine().Trim();
                    
                    if(char.IsDigit(input, 0))
                    {
                        
                        inputNum = (int)char.GetNumericValue(input[0]);
                        if  (1 <= inputNum && inputNum <= 6)
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    //checks to see if input was a digit between 1 and 6 if not loops back on itself
                }
                switch(inputNum)
                {
                    case 1:
                        addNewItem();
                        break;
                    case 2:
                        listItems();
                        break;
                    case 3:
                        showTotalCost();
                        break;
                    case 4:
                        clearList();
                        break;
                    case 5:
                        saveToFile();
                        break;
                    case 6:
                        go = false;
                        break;
                }
            }
        }
        static void addNewItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the item");
            string itemName = Console.ReadLine().Trim();
            string quantity;
            while(true)
            {
                Console.WriteLine("Please enter the amount");
                quantity = Console.ReadLine();
                if (int.TryParse(quantity, out int i) && i >= 0)
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                }
            }
            string unitPrice;
            while(true)
            {
                Console.WriteLine("Please enter the cost of a unit");
                unitPrice = Console.ReadLine();
                if (int.TryParse(unitPrice, out int i) && i >= 0)
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                }
            }
            Console.Clear();
            while(true)
            {
                Console.WriteLine($"Do you want to add {quantity} {itemName}s at ${unitPrice} each? Y/N");
                string input = Console.ReadLine();
                if (input.ToUpper() != "Y" && input.ToUpper() != "N")
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                }
                else
                {
                    if(input.ToUpper() == "Y")
                    {
                        Item itemToAdd = new Item(itemName,quantity,unitPrice);
                        itemList.Add(itemToAdd);
                        Console.Clear();
                        Console.WriteLine("Item added");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Item Not added");
                    }
                    break;
                }
            }
        }
        
        static void listItems()
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                Console.WriteLine($"Name: {itemList[i].title} Quantity: {itemList[i].quantity} Unit Price: ${itemList[i].unitPrice}");
            }
            while(true)
            {
                Console.WriteLine("Would you like to return? Y/N");
                string input = Console.ReadLine();
                    if (input.ToUpper() != "Y" && input.ToUpper() != "N")
                    {
                        Console.WriteLine("Incorrect Input");
                    }
                    else
                    {
                        if(input.ToUpper() == "Y")
                        {
                            Console.Clear();
                            break;
                        }
                    }
            }
        }

        static void showTotalCost()
        {
            Console.Clear();
            int total = 0;
            for (int i = 0; i < itemList.Count(); i++)
            {
                total += int.Parse(itemList[i].quantity) * int.Parse(itemList[i].unitPrice);
            }
            Console.WriteLine($"The total cost is: ${total}");
        }

        static void clearList()
        {
            itemList.Clear();
            File.Delete("./list.csv");
        }
        static void saveToFile()
        {
            using (StreamWriter writer = new StreamWriter("./list.csv"))
            {
                for (int i = 0; i < itemList.Count(); i++)
                {
                    writer.WriteLine($"{itemList[i].title},{itemList[i].quantity},{itemList[i].unitPrice}");
                }
            }
            
        }
    }
}
