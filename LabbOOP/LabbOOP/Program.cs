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
            ProductChild apple = new ProductChild();


            Boolean case3 = true;

            while (case3)
            {
                Console.WriteLine("Click 1 to choose Apple");
                Console.WriteLine("Click 2 to choose Dog");
                Console.WriteLine("Click 3 to choose Nocco");
                Console.WriteLine("Click 4 to exit");
                var customerInput = Convert.ToInt32(Console.ReadLine());

                switch (customerInput)
                {
                    case 1:
                        Console.WriteLine("Click 1 for a red apple");
                        Console.WriteLine("Click 2 for a brown apple");
                        var customerInupt2 = Convert.ToInt32(Console.ReadLine());

                        switch (customerInupt2)
                        {
                            case 1:
                                customer1._cart.Add(apple._freshapple);
                                break;

                            case 2:
                                customer1._cart.Add(apple._badapple);
                                break;

                        }

                        break;

                    case 2:
                        customer1._cart.Add(products._dog);

                        break;

                    case 3:
                        customer1._cart.Add(products._nocco);

                        break;

                    case 4:
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
