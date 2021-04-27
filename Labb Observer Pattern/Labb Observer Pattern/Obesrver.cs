using Labb_Observer_Pattern.ObserverPatternDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Observer_Pattern
{
    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }
            
        public Observer(string name)
        {
            ObserverName = name;
        }

        public void Update()
        {
            Console.WriteLine(ObserverName + ": A new product has arrived at the store");
        }
    }
}

