using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift08
{
    class ShoppingList
    {
        public string item, choice;
        public int menu;
        public List<string> shoppingList = new List<string>();
        public bool addOrRemove, showMenu = true;

        public virtual void AddItems()
        {
            Console.WriteLine("Do you want to add another item? Y/N");
            choice = Console.ReadLine();
            if (choice == "Y" || choice == "y") { addOrRemove = true; }
            else 
            {
                Console.WriteLine("\nOkey, no more items will be added.");
                addOrRemove = false;    
            }
        }          
        public virtual void RemoveItems()
        {
            Console.WriteLine("\nDo you want to remove another item? Y/N");
                choice = Console.ReadLine();
                if (choice == "Y" || choice == "y") { addOrRemove = true; }
                else 
                { 
                    Console.WriteLine("\nNo more items will be removed."); 
                    addOrRemove  = false;
                }
        }
        public virtual void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"ShoppingList.txt", shoppingList);
            Console.WriteLine("All items are removed from your shopping list.");
        }
        public virtual void DisplayList()
        {
            UpdateShoppingList();
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThe shopping list is currently empty."); }
        }
        public void UpdateShoppingList()
        {
            if (shoppingList.Count() != 0)  { shoppingList.Clear(); }
            string [] shoppingArray;
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
    }
    class Bread : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the bread type to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"Bread.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("Bread.txt"))
            {
                string[] breads = File.ReadAllLines(@"Bread.txt");
                shoppingList.Clear();
                foreach (var i in breads) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no bread in your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the bread type to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"Bread.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"Bread.txt", shoppingList);
            Console.WriteLine("All breads are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] breads = File.ReadAllLines(@"Bread.txt");
            shoppingList.Clear();
            foreach (var i in breads) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe bread section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no breads in your shoping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a bread product\n2. Remove a bread product\n3. Clear the bread section\n4. Display the bread section\n5. Back to main menu\n========================");
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
    class ColonialGoods : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the colonial product to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"ColonialGoods.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("ColonialGoods.txt"))
            {
                string[] colonials = File.ReadAllLines(@"ColonialGoods.txt");
                shoppingList.Clear();
                foreach (var i in colonials) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no colonial goods in your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the colonial product to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"ColonialGoods.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"ColonialGoods.txt", shoppingList);
            Console.WriteLine("All colonial products are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] colonials = File.ReadAllLines(@"ColonialGoods.txt");
            shoppingList.Clear();
            foreach (var i in colonials) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe colonial goods section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no colonial goods in your shoping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a colonial product\n2. Remove a colonial product\n3. Clear the colonial goods section\n4. Display the colonial goods section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }    
            } while (showMenu == true);
        }
    }
    class Dairy : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the dairy product to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"Dairy.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("Dairy.txt"))
            {
                string[] dairies = File.ReadAllLines(@"Dairy.txt");
                shoppingList.Clear();
                foreach (var i in dairies) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no dairy products on your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the dairy product to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"Dairy.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"Dairy.txt", shoppingList);
            Console.WriteLine("All dairy products are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] dairies = File.ReadAllLines(@"Dairy.txt");
            shoppingList.Clear();
            foreach (var i in dairies) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe dairy section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no dairy products in your shoping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a dairy product\n2. Remove a dairy product\n3. Clear the dairy section\n4. Display the dairy section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);    
        }
    }
    class FrozenGoods : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the frozen product to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"FrozenGoods.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("FrozenGoods.txt"))
            {
                string[] frozen = File.ReadAllLines(@"FrozenGoods.txt");
                shoppingList.Clear();
                foreach (var i in frozen) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no frozen goods in your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the frozen product to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"FrozenGoods.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"FrozenGoods.txt", shoppingList);
            Console.WriteLine("All frozen products are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] frozen = File.ReadAllLines(@"FrozenGoods.txt");
            shoppingList.Clear();
            foreach (var i in frozen) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe frozen goods section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no frozen goods in your shoping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a frozen product\n2. Remove a frozen product\n3. Clear the frozen goods section\n4. Display the frozen goods section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);    
        }
    }
    class MeatAndFish : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the meat or fish to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"MeatAndFish.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("MeatAndFish.txt"))
            {
                string[] meatFish = File.ReadAllLines(@"MeatAndFish.txt");
                shoppingList.Clear();
                foreach (var i in meatFish) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no meat or fish on your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the meat or fish to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"MeatAndFish.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"MeatAndFish.txt", shoppingList);
            Console.WriteLine("All meat and fish products are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] meatFish = File.ReadAllLines(@"MeatAndFish.txt");
            shoppingList.Clear();
            foreach (var i in meatFish) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe meat and fish section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no meat or fish in your shopping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a meat or fish product\n2. Remove a meat or fish product\n3. Clear the meat and fish section\n4. Display the meat and fish section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);    
        }
    }
    class Miscellaneous : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the miscellaneous product to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"Miscellaneous.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("Miscellaneous.txt"))
            {
                string[] miscellaneous = File.ReadAllLines(@"Miscellaneous.txt");
                shoppingList.Clear();
                foreach (var i in miscellaneous) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no miscellaneous products on your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the miscellaneous product to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"Miscellaneous.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"Miscellaneous.txt", shoppingList);
            Console.WriteLine("All miscellaneous products are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] miscellaneous = File.ReadAllLines(@"Miscellaneous.txt");
            shoppingList.Clear();
            foreach (var i in miscellaneous) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe miscellaneous section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no miscellaneous products in your shopping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a miscellaneous product\n2. Remove a miscellaneous product\n3. Clear the miscellaneous section\n4. Display the miscellaneous section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);    
        }
    }
    class Vegetables : ShoppingList
    {
        public override void AddItems()
        {
            do
            {
                Console.WriteLine("\nEnter the vegetable product to add it on your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                File.AppendAllText(@"Vegetables.txt", item + "\n");
                Console.WriteLine(item + " added!\n");
                base.AddItems();
            } while (addOrRemove == true);
        }
        public override void RemoveItems()
        {
            if (File.Exists("Vegetables.txt"))
            {
                string[] vegetables = File.ReadAllLines(@"Vegetables.txt");
                shoppingList.Clear();
                foreach (var i in vegetables) { shoppingList.Add(i); }
                addOrRemove = true;
            }
            else
            {
                Console.WriteLine("There is no vegetables on your shopping list.");
                addOrRemove = false;
            }
            while (addOrRemove == true)
            {    
                Console.WriteLine("\nEnter the vegetables to remove it from your shopping list: ");
                item = Console.ReadLine();
                item = item.ToUpper();
                if (shoppingList.Count() != 0)
                {
                    foreach (var i in shoppingList)
                    {
                        if (i == item)
                        {
                            shoppingList.Remove(item);
                            File.WriteAllLines(@"Vegetables.txt", shoppingList);
                            Console.WriteLine(item + " removed!");
                            break;
                        }
                        else if (i != item) { continue; }                       
                        else    { Console.WriteLine("\n" + item + " is not on the shopping list."); }
                    } 
                }
                else { addOrRemove = false; }
                base.RemoveItems();
            } 
        }
        public override void ClearList()
        {
            shoppingList.Clear();
            File.WriteAllLines(@"Vegetables.txt", shoppingList);
            Console.WriteLine("All vegetables are removed from your shopping list.");
        }
        public override void DisplayList()
        {
            string[] vegetables = File.ReadAllLines(@"Vegetables.txt");
            shoppingList.Clear();
            foreach (var i in vegetables) { shoppingList.Add(i); }
            if (shoppingList.Count() != 0)
            {
            Console.WriteLine("\nThe vegetable section in your shopping list contains this goods: ");
            shoppingList.ForEach(Console.WriteLine);
            } else  { Console.WriteLine("\nThere is no vegetables in your shopping list."); }
        }
        public void Menu()
        {
            do
            {
                Console.WriteLine("\n========================\n1. Add a vegetable\n2. Remove a vegetable\n3. Clear the vegetable section\n4. Display the vegetable section\n5. Back to main menu\n========================");
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
                        break;
                    default:
                        Console.WriteLine("No valid entry, automatic re-direct to main menu.");
                        break;
                }
            } while (showMenu == true);  
        }
    }
}