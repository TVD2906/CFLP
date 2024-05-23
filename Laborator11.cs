//Să presupunem că ai o listă de obiecte de tip Student, fiecare student având un nume și o listă de note. Dorești să efectuezi diferite operații pe această listă folosind LINQ.

//Implementează o metodă pentru a găsi toți studenții care au obținut media notelor mai mare sau egală cu 7.
//Implementează o metodă pentru a calcula media notelor pentru fiecare student.
//Implementează o metodă pentru a găsi cea mai mare notă obținută de un student.
//Implementează o metodă pentru a sorta studenții după media notelor în ordine descrescătoare.



using System;
using System.Collections.Generic;
using System.Linq;

class Student {
    public string Name { get; set; }
    public List<int> Grades { get; set; }

    public Student(string name, List<int> grades) {
        Name = name;
        Grades = grades;
    }
}

class Program {
    static void Main(string[] args) {
        List<Student> students = new List<Student> {
            new Student("John", new List<int> { 8, 7, 9 }),
            new Student("Alice", new List<int> { 6, 8, 7 }),
            new Student("Bob", new List<int> { 9, 9, 8 }),
            new Student("Emily", new List<int> { 7, 7, 6 }),
            new Student("David", new List<int> { 8, 9, 8 })
        };

        var studentsWithHighAverage = students.Where(s => s.Grades.Average() >= 7);

        Console.WriteLine("Students with average grade >= 7:");
        foreach (var student in studentsWithHighAverage) {
            Console.WriteLine(student.Name);
        }

        var averageGrades = students.Select(s => new {
            StudentName = s.Name,
            AverageGrade = s.Grades.Average()
        });

        Console.WriteLine("\nAverage grades for each student:");
        foreach (var avg in averageGrades) {
            Console.WriteLine($"{avg.StudentName}: {avg.AverageGrade}");
        }

        var maxGrade = students.SelectMany(s => s.Grades).Max();

        Console.WriteLine($"\nMaximum grade: {maxGrade}");

        var sortedStudents = students.OrderByDescending(s => s.Grades.Average());

        Console.WriteLine("\nStudents sorted by average grade (descending):");
        foreach (var student in sortedStudents) {
            Console.WriteLine($"{student.Name}: {student.Grades.Average()}");
        }
    }
}
