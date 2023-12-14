using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Store
{
    internal class Shop
    {
        private decimal OrderTotal;

        public Shop() 
        {
        OrderTotal = 0m;
        }
        public void Run() 
        {

            ForegroundColor = ConsoleColor.Red ;
            BackgroundColor = ConsoleColor.White ;
            Console.Clear();
            // Run all the shop logic here.
            DisplayIntro();
            Console.WriteLine();

            SellItem("Chopped Sword", 10.5m);
            Console.WriteLine();

            DisplayOrderTotal();
            Console.WriteLine();


            SellItem("Rusty Shield", 12.25m);
            Console.WriteLine();

            DisplayOrderTotal();
            Console.WriteLine();

            SellItem("Arepa", 1000.5m);
            Console.WriteLine();

            DisplayOrderTotal();
            Console.WriteLine();

            DisplayOutro();
        }
        private void DisplayIntro() 
        {
            Console.WriteLine("==================");
            Console.WriteLine("== Items 4 Gold ==");
            Console.WriteLine("==================");
        }
        private void SellItem(string itemName, decimal cost) 
        {
            Console.WriteLine($"Would You like to buy a(n) {itemName} for {cost:C2}? (y/n) ");
            string response = Console.ReadLine().ToUpper();
            if (response.StartsWith("Y"))
            {
                Console.WriteLine("How many would you like ?");
                string numResponse = Console.ReadLine();
                try
                {
                int quantity = Convert.ToInt32(numResponse);

                decimal itemTotal = cost * quantity;
                    OrderTotal += itemTotal;
                Console.WriteLine($"Okay, {quantity}x {itemName} is going to be {itemTotal:C2}");

                }
                catch (FormatException)
                {
                    Console.WriteLine("That wasn't a number... please try again");
                    SellItem(itemName, cost);
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That number was too high or to low... please try again");
                    SellItem(itemName, cost);
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Oh well, you dind't want a(n) {itemName}.");
            }
        }
        private void DisplayOrderTotal() 
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($">Your current order total is: {OrderTotal:C2}.");
            ForegroundColor = previousColor;
        }
        private void DisplayOutro() 
        {
            Console.WriteLine("Thanks for shopping");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
