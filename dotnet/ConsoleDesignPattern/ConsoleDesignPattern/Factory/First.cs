using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDesignPattern.Factory
{
    public abstract class PizzaStore : IPizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
            {
                pizza = new NYStyleCheesePizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new NYStyleVeggiePizza();
            }
            return pizza;
        }
    }   
}
