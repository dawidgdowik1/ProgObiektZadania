using System;
using ConsoleApp1; // Wszystkie klasy są widoczne

Console.WriteLine("--- START PROGRAMÓW LAB 3 I 4 ---");

// -------------------------------------------------------------
// SEKCJA 1: ZADANIA LAB 3 (Biblioteka i Samochody)
// -------------------------------------------------------------
TasksLab1 tasksLab1 = new TasksLab1();
TasksLab2 tasksLab2 = new TasksLab2();

tasksLab1.Run();
tasksLab2.Run();

// -------------------------------------------------------------
// SEKCJA 2: ZADANIA LAB 4 - ĆWICZENIE 1 
// -------------------------------------------------------------

Console.WriteLine("\n\n=============================================");
Console.WriteLine("ĆWICZENIE 1");
Console.WriteLine("=============================================");

Employee[] employees =
{
    new Employee("Jan", "Nowak"),
    new Employee("Jan1", "Nowak1", new Position(5200m, 10m)),
    new Employee("Jan2", "Nowak2"),
    new Employee("Jan3", "Nowa3", new Position(5200m, 120m))
};

foreach (var item in employees)
{
    Console.WriteLine(item.ToString());
    Console.WriteLine("------------------------------------------");
}


// -------------------------------------------------------------
// SEKCJA 3: ZADANIA LAB 4 
// -------------------------------------------------------------
TasksLab4 tasksLab4  = new TasksLab4();
TasksLab4.Run();
