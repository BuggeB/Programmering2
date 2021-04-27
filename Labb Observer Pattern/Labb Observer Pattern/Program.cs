using Labb_Observer_Pattern;
using System;

namespace ObserverPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            Observer observer1 = new Observer("Observer 1");
            subject.Subscribe(observer1);

            Observer observer2 = new Observer("Observer 2");
            subject.Subscribe(observer2);

            subject.Inventory++;

            Observer observer3 = new Observer("Observer 3");
            subject.Subscribe(observer3);

            subject.Inventory++;

            Console.ReadLine();
        }
    }
}