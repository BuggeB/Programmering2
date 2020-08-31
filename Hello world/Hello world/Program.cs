using System;

namespace Hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");

           
            string userName = Console.ReadLine();
            Console.WriteLine("Username is: " + userName);

            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your age is: " + age);

            Console.WriteLine("Lever du: yes/no");
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                Console.WriteLine("Bra att du lever");
            }
            else
            {
                Console.WriteLine("Synd att du är död... pee pee poo poo");
            }


        }
    }
}
