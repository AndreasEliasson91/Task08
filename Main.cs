using System;
using System.IO;

namespace Uppgift08
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingList shoppinglist = new ShoppingList();
            if (File.Exists("ShoppingList.txt"))
            {
                Console.WriteLine("A shopping list currently exists.");
                // shoppinglist.DisplayList();
                Console.WriteLine("\nDo you wish to start a new one and replace this? Y/N");
                string choice = Console.ReadLine();
                if (choice == "Y" || choice == "y") { File.WriteAllLines(@"ShoppingList.txt", shoppinglist.shoppingList); }
            } else
            {
                Console.WriteLine("No shopping list seems to exist.\nNew shopping list created!"); 
                File.Create("ShoppingList.txt");
            }
            Menu(shoppinglist);
            Console.ReadKey();
        }
        static void Menu(ShoppingList list)
        {
            bool showMenu = true;
            int menu;
            do
            {
                Console.WriteLine("\n========================\n1. Go to the bread section\n2. Go to the colonial goods section\n3. Go to the dairy section\n4. Go to the frozen goods section\n5. Go to the meat and fish section\n6. Go to the miscellaneous section\n7. Go to the vegetables section\n========================\n8. Display the shopping list\n9. Clear the shopping list\n10. Quit the application\n========================");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Bread bread01 = new Bread();
                        bread01.Menu();
                        break;
                    case 2:
                    //     ColonialGoods colonial01 = new ColonialGoods();
                    //     colonial01.Menu();
                    //     break;
                    // case 3:
                    //     Dairy dairy01 = new Dairy();
                    //     dairy01.Menu();
                    //     break;
                    // case 4:
                    //     FrozenGoods frozen01 = new FrozenGoods();
                    //     frozen01.Menu();
                    //     break;
                    // case 5:
                    //     MeatAndFish meatFish01 = new MeatAndFish();
                    //     meatFish01.Menu();
                    //     break;
                    // case 6:
                    //     Miscellaneous misc01 = new Miscellaneous();
                    //     misc01.Menu();
                    //     break;
                    // case 7:
                    //     Vegetables vegetable01 = new Vegetables();
                    //     vegetable01.Menu();
                    //     break;
                    // case 8:
                    //     list.DisplayList();
                    //     break;
                    case 9:
                        list.ClearList();
                        break;
                    case 10:
                        showMenu = false;
                        Console.WriteLine("\nThanks for using our application!");
                        break;
                    default:
                        Console.WriteLine("No valid entry, try again.");
                        break;
                }
            } while (showMenu == true);
        }
    }
}
