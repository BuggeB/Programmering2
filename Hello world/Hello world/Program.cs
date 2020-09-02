using System;

namespace Hello_world
{
    class Program
    {
        public static object Control { get; private set; }

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Ange en siffra mellan 1-2");

                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("stinky");
                        break;

                    case 2:
                        Console.WriteLine("poopey");
                        break;

                    default:
                        Console.WriteLine("Segt du får skriva 1 eller 2");              
                        break;

                }

                Console.WriteLine("Skriv sitt namn:");

           
            string userName = Console.ReadLine();

            Console.WriteLine("Du heter: " + userName);
               
            Console.WriteLine("Skriv din ålder:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Din ålder är: " + age);
                for (int i = 0; i < 18; i++)
                {
                    Console.WriteLine("Du är inte myndig skitunge -.-");
                    break;
                }

                Console.WriteLine("Lever du: ja/nej");
            var answer = Console.ReadLine();
            if (answer == "ja")
            {
                Console.WriteLine("Bra att du lever");
            }
            else
            {
                Console.WriteLine("Synd att du är död... pee pee poo poo");
                    break;
                    
            }
            }

            

           


        }
    }
}
