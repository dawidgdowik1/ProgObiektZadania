using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Zadania 1–5 z laboratorium 1
    /// </summary>
    /// <remarks>
    /// Autor: Dawid Gdowik
    /// Data: 12.11.2025
    /// Środowisko: .NET 9.0
    /// </remarks>
    internal class TasksLab1
    {
        public void Run()
        {
            // Wywołujemy wszystkie zadania po kolei
            Console.WriteLine("\nZadanie 1");
            Zadanie1();
            Console.WriteLine("\nZadanie 2");
            Zadanie2();
            Console.WriteLine("\nZadanie 3");
            Zadanie3();
            Console.WriteLine("\nZadanie 4");
            Zadanie4();
            Console.WriteLine("\nZadanie 5");
            Zadanie5();
        }

        private void Zadanie1()
        {
            //  Zadanie 1
            double delta, x1, x2;

            Console.WriteLine("Podaj a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Podaj b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Podaj c:");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a != 0)
            {
                delta = b * b - 4 * a * c;

                if (delta < 0)
                    Console.WriteLine("Brak pierwiastków rzeczywistych");
                else if (delta > 0)
                {
                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine($"x1 = {x1:F2}, x2 = {x2:F2}");
                }
                else
                {
                    x1 = -b / (2 * a);
                    Console.WriteLine($"x = {x1:F2}");
                }
            }
            else
            {
                Console.WriteLine("To nie jest równanie kwadratowe");
            }
        }

        private void Zadanie2()
        {
            // Zadanie 2
            

            // Wczytanie granic przedziału
            double min = LosujLiczbeOdUzytkownika("Podaj dolną granicę:");
            double max = LosujLiczbeOdUzytkownika("Podaj górną granicę:");

            // Losujemy tablicę 10 liczb
            double[] tab = LosujTabliceDouble(10, min, max);

            double suma = 0;
            double iloczyn = 1;
            double minWart = tab[0];
            double maxWart = tab[0];

            // Liczymy sumę, iloczyn, min i max
            foreach (var liczba in tab)
            {
                suma += liczba;
                iloczyn *= liczba;
                if (liczba < minWart) minWart = liczba;
                if (liczba > maxWart) maxWart = liczba;
            }

            double srednia = suma / tab.Length;

            // Wyświetlamy wyniki
            Console.WriteLine("Wylosowane liczby:");
            foreach (var l in tab) Console.Write($"{l:F2} ");
            Console.WriteLine($"\nSuma: {suma:F2}, Iloczyn: {iloczyn:F2}, Średnia: {srednia:F2}, Min: {minWart:F2}, Max: {maxWart:F2}");
        }

        private void Zadanie3()
        {
            // Zadanie 3
            

            for (int i = 20; i >= 0; i--)
            {
                if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19) continue; // pomijamy liczby
                Console.WriteLine(i);
            }
        }

        private void Zadanie4()
        {
            //  Zadanie 4
           

            while (true)
            {
                Console.Write("Podaj liczbę: ");
                int liczba = Convert.ToInt32(Console.ReadLine());

                if (liczba < 0)
                {
                    Console.WriteLine("Koniec programu");
                    break; // przerywamy pętlę
                }

                Console.WriteLine("Wpisałeś: " + liczba);
            }
        }

        private void Zadanie5()
        {
            // Zadanie 5
           

            Console.Write("Ile liczb wylosować? n = ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Wczytanie granic przedziału
            double min = LosujLiczbeOdUzytkownika("Podaj dolną granicę:");
            double max = LosujLiczbeOdUzytkownika("Podaj górną granicę:");

            // Losowanie tablicy
            double[] tab = LosujTabliceDouble(n, min, max);

            Console.WriteLine("Przed sortowaniem:");
            foreach (var l in tab) Console.Write($"{l:F2} ");
            Console.WriteLine();

            // Sortowanie bąbelkowe
            for (int i = 0; i < tab.Length - 1; i++)
                for (int j = 0; j < tab.Length - 1 - i; j++)
                    if (tab[j] > tab[j + 1])
                    {
                        double temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }

            Console.WriteLine("Po sortowaniu:");
            foreach (var l in tab) Console.Write($"{l:F2} ");
            Console.WriteLine();
        }


        /// <summary>
        /// Wczytuje liczbę od użytkownika z komunikatem
        /// </summary>
        private double LosujLiczbeOdUzytkownika(string komunikat)
        {
            Console.Write(komunikat + " ");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Losuje tablicę n liczb double z przedziału [min, max]
        /// </summary>
        private double[] LosujTabliceDouble(int n, double min, double max)
        {
            // Jeśli min > max, zamieniamy granice
            if (min > max)
            {
                double temp = min;
                min = max;
                max = temp;
                Console.WriteLine($"Zamieniono granice. Przedział: [{min}, {max}]");
            }

            double[] arr = new double[n];
            Random rng = new Random();

            // Losowanie każdej liczby
            for (int i = 0; i < n; i++)
                arr[i] = min + rng.NextDouble() * (max - min);

            return arr;
        }
    }
}