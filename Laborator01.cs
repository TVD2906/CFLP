using System;

//Creati o clasa în C# numita Student.
//Definiti urmatorii membri pentru clasa Student:
//Proprietatea Name pentru a stoca numele studentului.
//Proprietatea Age pentru a stoca varsta studentului.
//Metoda PrintInfo() pentru a afisa informatiile despre student.
//Implementati constructorul clasei Student care primeste doua argumente: numele si varsta studentului, si le atribuie proprietatilor corespunzatoare.
//Utilizati metoda PrintInfo() pentru a afisa informatiile despre un student specificat în metoda Main().
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Nume: {Name}");
        Console.WriteLine($"Varsta: {Age}");
        Console.WriteLine($"Nota medie: {AverageGrade}");
    }

    public void CalculateAverageGrade(double[] grades)
    {
        if (grades.Length > 0)
        {
            double sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
            }
            AverageGrade = sum / grades.Length;
        }
        else
        {
            AverageGrade = 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("John", 20);
        double[] grades = { 8.5, 9.0, 7.8, 8.9 };
        student.CalculateAverageGrade(grades);
        student.PrintInfo();
    }
}
