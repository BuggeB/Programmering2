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
            Liquid liquid = new Liquid();
            Snacks snacks = new Snacks();


            Boolean case3 = true;

            while (case3)
            {
                Console.WriteLine("Click 1 to choose Apple");
                Console.WriteLine("Click 2 to choose Dog");
                Console.WriteLine("Click 3 to choose Cola");
                Console.WriteLine("Click 4 to choose Nocco");
                Console.WriteLine("Click 5 to choose Chips");
                Console.WriteLine("Click 6 to choose Popcorn");
                Console.WriteLine("Click 7 to exit");
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
                        customer1._cart.Add(liquid._cola);

                        break;

                    case 4:
                        customer1._cart.Add(liquid._nocco);

                        break;

                    case 5:
                        customer1._cart.Add(snacks._chips);

                        break;

                    case 6:
                        customer1._cart.Add(snacks._popcorn);

                        break;

                    case 7:
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
