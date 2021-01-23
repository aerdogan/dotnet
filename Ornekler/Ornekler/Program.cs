using System;

namespace Ornekler
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> liste = new MyList<string>();
            liste.Add("Ahmet");
            liste.Add("Deneme");
            Console.WriteLine(liste.Length);

            foreach (var isimler in liste.Items)
            {
                Console.WriteLine(isimler);
            }
        }
    }
}
