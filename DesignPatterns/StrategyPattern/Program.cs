using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.CreditCalculatorBase = new After2010CreditCalculator();
            cm.SaveCredit();

            cm.CreditCalculatorBase = new Before2010CreditCalculator();
            cm.SaveCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before 2010");
        }        
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after 2010");
        }        
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();
        }
    }
}
