using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift08
{
    class ShoppingList
    {
        public string item, choice, category, file;
        public int menu;
        public string[] shoppingArray;
        public List<string> shoppingList = new List<string>();
        public bool add, remove, showMenu = true;
        public ShoppingList()
        {
            category = "grocery"; 
            file = "ShoppingList.txt";
        }
        public void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the " + category + " type to add it on your shopping list: ");
                item = Console.ReadLine().ToUpper();
                File.AppendAllText(@file, item + "\n");
                Console.WriteLine(item + " added!\nDo you want to add another item? Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y") { add = true; }
                else  { add = false; }
            } while (add == true);
            Console.WriteLine("No more " + category + " will be added");
        }          
        public void RemoveItems()
        {
            if (File.Exists(file))
            {
                shoppingArray = File.ReadAllLines(@file);
                shoppingList.Clear();
                foreach (var i in shoppingArray) { shoppingList.Add(i); }
                remove = true;
            }
            else
            {
                Console.WriteLine("There is no " + category + " in your shopping list.");
                remove = false;
            }
            while (remove == true)
            {    
                Console.WriteLine("\nEnter the " + category + " product to remove it from your shopping list: ");
                item = Console.ReadLine().ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@file, shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { remove = false; }
                Console.WriteLine("\nDo you want to remove another item? Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y") { remove = true; }
                else { remove  = false; }
                Console.WriteLine("\nNo more items will be removed."); 
            } 

        }
        public void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@file, shoppingList);
            Console.WriteLine("All " + category + " products are removed from your shopping list.");
        }
        public void DisplayList()
        {
            UpdateShoppingList();
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe " + category + " section contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThe " + category + " section is currently empty."); }
        }
        public void UpdateShoppingList()
        {
            if (shoppingList.Count() != 0)  { shoppingList.Clear(); }

            if (category == "grocery")
            {
                if (File.Exists(@"Bread.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"Bread.txt");
                    shoppingList.Add("\n============\nBREAD\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"ColonialGoods.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"ColonialGoods.txt");
                    shoppingList.Add("\n============\nCOLONIAL GOODS\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"Dairy.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"Dairy.txt");
                    shoppingList.Add("\n============\nDAIRY\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"FrozenGoods.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"FrozenGoods.txt");
                    shoppingList.Add("\n============\nFROZEN GOODS\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"MeatAndFish.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"MeatAndFish.txt");
                    shoppingList.Add("\n============\nMEAT AND FISH\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"Miscellaneous.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"Miscellaneous.txt");
                    shoppingList.Add("\n============\nMISCELLANEOUS\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
                if (File.Exists(@"Vegetables.txt"))
                {
                    shoppingArray = File.ReadAllLines(@"Vegetables.txt");
                    shoppingList.Add("\n============\nVEGETABLES\n============\n");
                    foreach (var i in shoppingArray) { shoppingList.Add(i); }
                }
            }
            else
            {
                shoppingArray = File.ReadAllLines(@file);
                shoppingList.Clear();
                foreach (var i in shoppingArray) { shoppingList.Add(i); }
            }        
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a " + category + " product\n2. Remove a "+ category +" product\n3. Clear the "+ category +" section\n4. Display the " + category + " section\n5. Back to main menu\n========================");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        AddItems();
                        break;
                    case 2:
                        RemoveItems();
                        break;
                    case 3:
                        ClearList();
                        break;
                    case 4:
                        DisplayList();
                        break;
                    case 5:
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);
        }
    }
    class Bread : ShoppingList
    {
        public Bread()
        {
            category = "bread";
            file = "Bread.txt";
        }
    }
    class ColonialGoods : ShoppingList
    {
                public ColonialGoods()
        {
            category = "colonial";
            file = "ColonialGoods.txt";
        }
    }
    class Dairy : ShoppingList
    {
        public Dairy()
        {
            category = "dairy";
            file = "Dairy.txt";
        }
    }
    class FrozenGoods : ShoppingList
    {
        public FrozenGoods()
        {
            category = "frozen";
            file = "FrozenGoods.txt";
        }
    }
    class MeatAndFish : ShoppingList
    {
        public MeatAndFish()
        {
            category = "meat or fish";
            file = "MeatAndFish.txt";
        }
    }
    class Miscellaneous : ShoppingList
    {
        public Miscellaneous()
        {
            category = "miscellaneous";
            file = "Miscellaneous.txt";
        }
    }
    class Vegetables : ShoppingList
    {
        public Vegetables()
        {
            category = "vegetable";
            file = "Vegetables.txt";
        }
    }
}