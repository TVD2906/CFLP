//Definiți o clasă Carte care să aibă următoarele proprietăți:

//ID - un identificator unic al cărții (int)
//Titlu - titlul cărții (string)
//Autor - autorul cărții (string)
//AnPublicare - anul publicării cărții (int)
//Definiți o clasă Biblioteca care să gestioneze colecția de cărți. Această clasă trebuie să aibă următoarele funcționalități:

//Adăugarea unei cărți în bibliotecă
//Listarea tuturor cărților disponibile în bibliotecă
//Căutarea unei cărți după titlu
//Căutarea cărților scrise de un anumit autor
//Implementați o metodă Main pentru a testa funcționalitățile bibliotecii:

//Adăugați câteva cărți în bibliotecă
//Listați cărțile din bibliotecă
//Căutați o carte după titlu și afișați detaliile acesteia
//Căutați cărțile scrise de un anumit autor și afișați detaliile acestora

using System;
using System.Collections.Generic;

class Carte
{
    public int ID { get; set; }
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public int AnPublicare { get; set; }

    public Carte(int id, string titlu, string autor, int anPublicare)
    {
        ID = id;
        Titlu = titlu;
        Autor = autor;
        AnPublicare = anPublicare;
    }
}

class Biblioteca
{
    private List<Carte> carti = new List<Carte>();

    public void AdaugaCarte(Carte carte)
    {
        carti.Add(carte);
    }

    public void ListaCarti()
    {
        Console.WriteLine("Carti disponibile in biblioteca:");
        foreach (var carte in carti)
        {
            Console.WriteLine($"ID: {carte.ID}, Titlu: {carte.Titlu}, Autor: {carte.Autor}, An publicare: {carte.AnPublicare}");
        }
    }

    public Carte CautaDupaTitlu(string titlu)
    {
        return carti.Find(carte => carte.Titlu.Equals(titlu, StringComparison.OrdinalIgnoreCase));
    }

    public List<Carte> CautaDupaAutor(string autor)
    {
        return carti.FindAll(carte => carte.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        biblioteca.AdaugaCarte(new Carte(1, "Marele Gatsby", "F. Scott Fitzgerald", 1925));
        biblioteca.AdaugaCarte(new Carte(2, "1984", "George Orwell", 1949));
        biblioteca.AdaugaCarte(new Carte(3, "Anna Karenina", "Lev Tolstoi", 1877));

        biblioteca.ListaCarti();

        string titluCautat = "1984";
        Carte carteDupaTitlu = biblioteca.CautaDupaTitlu(titluCautat);
        if (carteDupaTitlu != null)
        {
            Console.WriteLine($"Cartile cu titlul '{titluCautat}':");
            Console.WriteLine($"ID: {carteDupaTitlu.ID}, Titlu: {carteDupaTitlu.Titlu}, Autor: {carteDupaTitlu.Autor}, An publicare: {carteDupaTitlu.AnPublicare}");
        }
        else
        {
            Console.WriteLine($"Nu există nicio carte cu titlul '{titluCautat}'.");
        }

        // Cautare carti dupa autor
        string autorCautat = "Lev Tolstoi";
        List<Carte> cartiDupaAutor = biblioteca.CautaDupaAutor(autorCautat);
        if (cartiDupaAutor.Count > 0)
        {
            Console.WriteLine($"Cărțile scrise de autorul '{autorCautat}':");
            foreach (var carte in cartiDupaAutor)
            {
                Console.WriteLine($"ID: {carte.ID}, Titlu: {carte.Titlu}, Autor: {carte.Autor}, An publicare: {carte.AnPublicare}");
            }
        }
        else
        {
            Console.WriteLine($"Nu există nicio carte scrisă de autorul '{autorCautat}'.");
        }
    }
}
