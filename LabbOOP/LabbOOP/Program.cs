using System;
using System.Dynamic;

namespace LabbOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Console.WriteLine("Enter Customer's name");
            customer1._name = Console.ReadLine();
            



            Product products = new Product();

            Boolean case3 = true;

            while (case3)
            {
                Console.WriteLine("Click 1 to choose Apple");
                Console.WriteLine("Click 2 to choose Dog");
                Console.WriteLine("Click 3 to exit");
                var customerInput = Convert.ToInt32(Console.ReadLine());

                switch (customerInput)
                {
                    case 1:
                        customer1._cart.Add(products._apple);
                        
                        break;

                    case 2:
                        customer1._cart.Add(products._dog);
                        
                        break;

                    case 3:
                        case3 = false;
                        Console.WriteLine("Exiting...");
                        break;
                        
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }

                foreach (var i in customer1._cart)
                {
                    Console.WriteLine(i);
                }
                


            }
            


        }
    }  
}
