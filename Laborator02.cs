using System;
using System.Collections.Generic;
/*In cadrul unui proiect de gestionare a datelor pentru o librarie, trebuie sa implementam diferite structuri si clase pentru a reprezenta cartile, clientii si imprumuturile acestora. Fiecare carte trebuie sa aiba un titlu, un autor si un cod unic, iar fiecare client trebuie sa fie identificat printr-un nume si un numar de identificare. De asemenea, dorim sa tinem evidenta imprumuturilor, tinand cont de data imprumutului, data returnarii si starea cartii (imprumutata sau disponibila).

Definiti o structura Carte care sa contina campurile pentru titlu, autor si cod unic.
Implementati o clasa Client cu campurile pentru nume si numar de identificare.
Creati o alta clasa numita Imprumut pentru a reprezenta fiecare imprumut, cu campurile pentru data imprumutului, data returnarii si starea cartii.
Asigurati-va ca fiecare carte si fiecare client au o metoda AfiseazaDetalii() pentru a putea afisa informatiile despre ele.
Implementati o clasa Biblioteca care sa contina listele de carti si clienti, precum si metode pentru imprumut si returnare.
Implementati functionalitatile necesare pentru a adauga carti si clienti, a imprumuta si a returna carti, precum si pentru a afisa starea curenta a bibliotecii.*/
namespace GestionareBiblioteca
{
    struct Carte
    {
        public string Titlu;
        public string Autor;
        public int CodUnic;

        public void AfiseazaDetalii()
        {
            Console.WriteLine($"Titlu: {Titlu}, Autor: {Autor}, Cod Unic: {CodUnic}");
        }
    }

    class Client
    {
        public string Nume;
        public int NumarIdentificare;

        public void AfiseazaDetalii()
        {
            Console.WriteLine($"Nume Client: {Nume}, Numar Identificare: {NumarIdentificare}");
        }
    }

    class Imprumut
    {
        public DateTime DataImprumut;
        public DateTime DataReturnare;
        public bool EsteImprumutata;

        public void AfiseazaDetalii()
        {
            Console.WriteLine($"Data Imprumut: {DataImprumut}, Data Returnare: {DataReturnare}, Este Imprumutata: {EsteImprumutata}");
        }
    }

    class Biblioteca
    {
        private List<Carte> carti = new List<Carte>();
        private List<Client> clienti = new List<Client>();
        private List<Imprumut> imprumuturi = new List<Imprumut>();

        public void AdaugaCarte(Carte carte)
        {
            carti.Add(carte);
        }

        public void AdaugaClient(Client client)
        {
            clienti.Add(client);
        }

        public void ImprumutaCarte(Carte carte, Client client)
        {
            if (carti.Contains(carte))
            {
                Imprumut imprumut = new Imprumut
                {
                    DataImprumut = DateTime.Now,
                    EsteImprumutata = true
                };
                imprumuturi.Add(imprumut);

                Console.WriteLine($"Cartea '{carte.Titlu}' a fost imprumutata catre {client.Nume}.");
            }
            else
            {
                Console.WriteLine($"Ne pare rau, cartea '{carte.Titlu}' nu este disponibila.");
            }
        }

        public void ReturneazaCarte(Carte carte, Client client)
        {
            bool esteImprumutataDeClient = false;
            foreach (var imprumut in imprumuturi)
            {
                if (imprumut.EsteImprumutata && carti.Contains(carte))
                {
                    esteImprumutataDeClient = true;
                    break;
                }
            }

            if (esteImprumutataDeClient)
            {
                foreach (var imprumut in imprumuturi)
                {
                    if (imprumut.EsteImprumutata)
                    {
                        imprumut.EsteImprumutata = false;
                        imprumut.DataReturnare = DateTime.Now;
                        break;
                    }
                }

                Console.WriteLine($"Cartea '{carte.Titlu}' a fost returnata de catre {client.Nume}.");
            }
            else
            {
                Console.WriteLine($"Ne pare rau, cartea '{carte.Titlu}' nu a fost imprumutata de catre {client.Nume}.");
            }
        }

        public void AfiseazaStareaCurenta()
        {
            Console.WriteLine("----- Starea Curenta a Bibliotecii -----");
            Console.WriteLine("Carti Disponibile:");
            foreach (var carte in carti)
            {
                carte.AfiseazaDetalii();
            }
            Console.WriteLine("\nLista de Clienti:");
            foreach (var client in clienti)
            {
                client.AfiseazaDetalii();
            }
            Console.WriteLine("\nImprumuturi in Desfasurare:");
            foreach (var imprumut in imprumuturi)
            {
                imprumut.AfiseazaDetalii();
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            Carte carte1 = new Carte { Titlu = "Mandrie si Prejudecata", Autor = "Jane Austen", CodUnic = 1 };
            Carte carte2 = new Carte { Titlu = "Harry Potter si Piatra Filozofala", Autor = "J.K. Rowling", CodUnic = 2 };
            biblioteca.AdaugaCarte(carte1);
            biblioteca.AdaugaCarte(carte2);

            Client client1 = new Client { Nume = "Elena Popescu", NumarIdentificare = 1001 };
            Client client2 = new Client { Nume = "Vlad Toderas", NumarIdentificare = 1002 };
            biblioteca.AdaugaClient(client1);
            biblioteca.AdaugaClient(client2);

            biblioteca.ImprumutaCarte(carte1, client1);

            biblioteca.ImprumutaCarte(carte1, client2);

            biblioteca.ReturneazaCarte(carte1, client1);

            biblioteca.AfiseazaStareaCurenta();
        }
    }
}
