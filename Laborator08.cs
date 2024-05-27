//Scrieți o clasă în C# care să reprezinte o listă de numere întregi. Această clasă ar trebui să ofere următoarele funcționalități:

//Adăugare de elemente: O metodă care să permită adăugarea unui număr întreg în listă.
//Accesare elemente: O metodă care să permită accesarea elementului de la un anumit index din listă.
//Actualizare elemente: O metodă care să permită actualizarea valorii unui element la un anumit index din listă.
//Ștergere de elemente: O metodă care să permită ștergerea elementului de la un anumit index din listă.
//Căutare de elemente: O metodă care să permită căutarea unui element în listă și să returneze indexul său sau -1 dacă nu este găsit.



using System;

class Program
{
    static void Main(string[] args)
    {
        MyIntegerList list = new MyIntegerList();

        list.Add(10);
        list.Add(20);
        list.Add(30);

        Console.WriteLine("Elementul de la indexul 1: " + list.Get(1));

        list.Update(1, 50);
        Console.WriteLine("Elementul de la indexul 1 dupa actualizare: " + list.Get(1));

        list.Delete(0);
        Console.WriteLine("Elementul de la indexul 0 dupa stergere: " + list.Get(0));

        int index = list.Search(30);
        if (index != -1)
        {
            Console.WriteLine("Elementul 30 se gaseste la indexul: " + index);
        }
        else
        {
            Console.WriteLine("Elementul 30 nu a fost gasit in lista.");
        }

        try
        {
            Console.WriteLine(list.Get(10));
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Eroare: " + ex.Message);
        }
    }
}

class MyIntegerList
{
    private int[] elements;
    private int size;

    public MyIntegerList()
    {
        elements = new int[10];
        size = 0;
    }

    public void Add(int value)
    {
        if (size < elements.Length)
        {
            elements[size] = value;
            size++;
        }
        else
        {
            Array.Resize(ref elements, elements.Length * 2);
            elements[size] = value;
            size++;
        }
    }

    public int Get(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Indexul este invalid.");
        }
        return elements[index];
    }

    public void Update(int index, int value)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Indexul este invalid.");
        }
        elements[index] = value;
    }

    public void Delete(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Indexul este invalid.");
        }
        for (int i = index; i < size - 1; i++)
        {
            elements[i] = elements[i + 1];
        }
        size--;
    }

    public int Search(int value)
    {
        for (int i = 0; i < size; i++)
        {
            if (elements[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
}
