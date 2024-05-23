//Clase și Proprietăți:

//Cartea: Reprezintă o carte din bibliotecă.
//Proprietăți: ID, Titlu, Autor, AnPublicare.
//Biblioteca: Reprezintă colecția de cărți.
//Proprietăți: ListaCarti (o listă de obiecte de tip Cartea).
//Metode: AdaugaCarte, ListareCarti, CautaCarteDupaTitlu, CautaCarteDupaAutor.

//Funcționalități:

//Adăugarea unei cărți noi în bibliotecă.
//Listarea tuturor cărților din bibliotecă.
//Căutarea unei cărți după titlu.
//Căutarea unei cărți după autor.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            
            biblioteca.AdaugaCarte(new Cartea(1, "Mandrie si prejudecata", "Jane Austen", 1813));
            biblioteca.AdaugaCarte(new Cartea(2, "Razboi si pace", "Lev Tolstoi", 1869));
            biblioteca.AdaugaCarte(new Cartea(3, "1984", "George Orwell", 1949));
            
            Console.WriteLine("Lista cartilor din biblioteca:");
            biblioteca.ListareCarti();
            
            Console.WriteLine("\nCautare carte dupa titlu ('1984'):");
            Cartea carteGasitaTitlu = biblioteca.CautaCarteDupaTitlu("1984");
            if (carteGasitaTitlu != null)
                Console.WriteLine(carteGasitaTitlu);
            else
                Console.WriteLine("Cartea nu a fost gasita.");
            
            Console.WriteLine("\nCautare carte dupa autor ('Jane Austen'):");
            List<Cartea> cartiGasiteAutor = biblioteca.CautaCarteDupaAutor("Jane Austen");
            if (cartiGasiteAutor.Any())
                cartiGasiteAutor.ForEach(carte => Console.WriteLine(carte));
            else
                Console.WriteLine("Nicio carte de acest autor nu a fost gasita.");
        }
    }

    class Cartea
    {
        public int ID { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int AnPublicare { get; set; }

        public Cartea(int id, string titlu, string autor, int anPublicare)
        {
            ID = id;
            Titlu = titlu;
            Autor = autor;
            AnPublicare = anPublicare;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Titlu: {Titlu}, Autor: {Autor}, AnPublicare: {AnPublicare}";
        }
    }

    class Biblioteca
    {
        private List<Cartea> ListaCarti { get; set; }

        public Biblioteca()
        {
            ListaCarti = new List<Cartea>();
        }

        public void AdaugaCarte(Cartea carte)
        {
            ListaCarti.Add(carte);
        }

        public void ListareCarti()
        {
            ListaCarti.ForEach(carte => Console.WriteLine(carte));
        }

        public Cartea CautaCarteDupaTitlu(string titlu)
        {
            return ListaCarti.FirstOrDefault(carte => carte.Titlu.Equals(titlu, StringComparison.OrdinalIgnoreCase));
        }

        public List<Cartea> CautaCarteDupaAutor(string autor)
        {
            return ListaCarti.Where(carte => carte.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
