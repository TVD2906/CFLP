//Să se implementeze o metodă în C# care primește ca parametru o listă de numere întregi și returnează o listă care conține dublul fiecărui număr din lista inițială.

//Cerințe suplimentare:

//Implementați această metodă folosind abordarea programării funcționale, fără a modifica lista inițială.
//Utilizați expresii lambda și metodele din biblioteca standard LINQ pentru a rezolva problema.
//Testați metoda cu diverse liste de numere întregi pentru a vă asigura că funcționează corect în diverse scenarii.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> doubledNumbers1 = DoubleNumbersFunctional(numbers1);
        Console.WriteLine("Lista initiala: " + string.Join(", ", numbers1));
        Console.WriteLine("Dublul fiecarui numar: " + string.Join(", ", doubledNumbers1));

        List<int> numbers2 = new List<int> { 0, -1, 10, -5, 100 };
        List<int> doubledNumbers2 = DoubleNumbersFunctional(numbers2);
        Console.WriteLine("Lista initiala: " + string.Join(", ", numbers2));
        Console.WriteLine("Dublul fiecarui numar: " + string.Join(", ", doubledNumbers2));
    }

    static List<int> DoubleNumbersFunctional(List<int> numbers)
    {
        return numbers.Select(x => x * 2).ToList();
    }
}
