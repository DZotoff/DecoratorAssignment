
namespace DecoratorAssignment
{
    // Instructions
    // You can implement your whole solution here
    // Optionally you can use folder structure if you deem it necessary
    // For this Assignment we will use Decorator pattern example introduced in the book Head First Design Patterns by O'Reilly
    // Chapeter 3 the DecoratorPattern: Decorating Objects (starts at page 79)
    // Link to pdf: https://github.com/ajitpal/BookBank/blob/master/%5BO%60Reilly.%20Head%20First%5D%20-%20Head%20First%20Design%20Patterns%20-%20%5BFreeman%5D.pdf
    // NOTE: Remember that the code examples in this book are written in java so you can't just copy the code examples given there

    public abstract class Beverage
    {
        public abstract decimal Cost();
        public string Description;
        public string GetDescription() => Description; 
    }
    public class Espresso : Beverage
    {
        public Espresso() =>  Description = "Espresso";
        public override decimal Cost() => 1.99M;
    }
    public class HouseBlend : Beverage
    {
        public HouseBlend() => Description = "House blend";
        public override decimal Cost() => 0.89M;
    }
    public class DarkRoast : Beverage
    {
        public DarkRoast() => Description = "Dark roast";
        public override decimal Cost() => 0.99M;
    }
    public class Decaf : Beverage
    {
        public Decaf() => Description = " Decaf";
        public override decimal Cost() => 1.05M;
    }
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;
        public CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }
    }
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage)
        {
            Description = beverage.GetDescription() + ", Mocha";
        }
        public override decimal Cost()
        {
            return beverage.Cost() + 0.20M;
        }
    }
    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage) : base(beverage)
        {
            Description = beverage.GetDescription() + ", Soy";
        }
        public override decimal Cost()
        {
            return beverage.Cost() + 0.15M;
        }
    }
    public class WhippedCream : CondimentDecorator
    {
        public WhippedCream(Beverage beverage) : base(beverage)
        {
            Description = beverage.GetDescription() + ", Whip";
        }
        public override decimal Cost()
        {
            return beverage.Cost() + 0.10M;
        }
    }
    public class SteamedMilk : CondimentDecorator
    {
        public SteamedMilk(Beverage beverage) : base(beverage)
        {
            Description = beverage.GetDescription() + ", Milk";
        }
        public override decimal Cost()
        {
            return beverage.Cost() + 0.20M;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage darkRoast = new DarkRoast();
            // Decorate it with Mocha and Whipped Cream
            darkRoast = new Mocha(darkRoast);
            darkRoast = new WhippedCream(darkRoast);
            Console.WriteLine($"Description: {darkRoast.GetDescription()}");
            Console.WriteLine($"Cost: ${darkRoast.Cost()}");

            Beverage houseblend = new HouseBlend();
            houseblend = new Mocha(houseblend);
            houseblend = new WhippedCream(houseblend);
            Console.WriteLine($"Description: {houseblend.GetDescription()}");
            Console.WriteLine($"Cost: ${houseblend.Cost()}");

            Beverage decaf = new Decaf();
            decaf = new Mocha(decaf);
            decaf = new WhippedCream(decaf);
            Console.WriteLine($"Description: {decaf.GetDescription()}");
            Console.WriteLine($"Cost: ${decaf.Cost()}");

            Beverage espresso = new Espresso(); 
            espresso = new Mocha(espresso);
            espresso = new WhippedCream(espresso);
            Console.WriteLine($"Description: {espresso.GetDescription()}");
            Console.WriteLine($"Cost: ${espresso.Cost()}");


        }
    }
}