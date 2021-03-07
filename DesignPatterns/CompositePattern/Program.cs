using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {            
            Employee ahmet = new Employee { Name = "Ahmet" };            
            Employee berat = new Employee { Name = "Ali" };
            Employee elif = new Employee { Name = "Hasan" };
            Employee malike = new Employee { Name = "Hüseyin" };
            Contractor test = new Contractor { Name = "Test" };

            ahmet.AddSubOrdinate(berat);
            ahmet.AddSubOrdinate(elif);
            elif.AddSubOrdinate(malike);
            berat.AddSubOrdinate(test);

            Console.WriteLine(ahmet.Name);
            foreach (Employee manager in ahmet)
            {
                Console.WriteLine("  {0}", manager.Name);
                foreach (IPerson employe in manager)
                {
                    Console.WriteLine("    {0}", employe.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        
        public void AddSubOrdinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        
        public void RemoveSubOrdinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
