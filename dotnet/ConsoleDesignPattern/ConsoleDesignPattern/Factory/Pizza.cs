using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPattern.Factory
{
    using System;
    using System.Collections.Generic;

    //namespace HeadFirst.DesignPatterns.Factory.Pizzas
        public abstract class Pizza
        {
            protected string name;
            protected string dough;
            protected string sauce;
            protected List<string> toppings = new List<string>();

            public string GetName()
            {
                return name;
            }

            public void Prepare()
            {
                Console.WriteLine("Preparing " + name);
            }

            public void Bake()
            {
                Console.WriteLine("Baking " + name);
            }

            public void Cut()
            {
                Console.WriteLine("Cutting " + name);
            }

            public void Box()
            {
                Console.WriteLine("Boxing " + name);
            }

            public override string ToString()
            {
                // code to display pizza name and ingredients
                var display = new System.Text.StringBuilder();
                display.AppendLine("---- " + name + " ----");
                display.AppendLine(dough);
                display.AppendLine(sauce);
                foreach (var topping in toppings)
                {
                    display.AppendLine(topping);
                }
                return display.ToString();
            }
        }


}
