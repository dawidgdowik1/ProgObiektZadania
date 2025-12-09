using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Zadania 1-5 (Programowanie Obiektowe)
    /// </summary>
    /// <remarks>
    /// Autor: Dawid Gdowik  
    /// Data: 12.11.2025  
    /// Środowisko: .NET 9.0  
    /// </remarks>
    internal class TasksLab2
    {
        public void Run()
        {
            Console.WriteLine("\n Zadanie 1");
            Zadanie1();

            Console.WriteLine("\n Zadanie 2");
            Zadanie2();

            Console.WriteLine("\n Zadanie 3");
            Zadanie3();

            Console.WriteLine("\n Zadanie 4");
            Zadanie4();

            Console.WriteLine("\n Zadanie 5");
            Zadanie5();
        }

        // Zadanie 1
        private void Zadanie1()
        {
            // Tworzenie nowego obiektu klasy Osoba
            Osoba osoba = new Osoba("Jan", "Kowalski", 25);
            osoba.WyswietlInformacje();
        }

        // Zadanie 2
        private void Zadanie2()
        {
            // Utworzenie przykładowego konta z początkowym saldem
            BankAccount konto = new BankAccount("Jan Kowalski", 1000);
            konto.Wplata(500); // wpłata środków
            konto.Wyplata(200); // wypłata środków
            Console.WriteLine($"Saldo końcowe: {konto.Saldo} zł");
        }

        // Zadanie 3
        private void Zadanie3()
        {
            // Tworzenie studenta i dodawanie ocen
            Student student = new Student("Anna", "Nowak");
            student.DodajOcene(5);
            student.DodajOcene(4);
            student.DodajOcene(3);

            Console.WriteLine($"Średnia ocen studenta {student.Imie} {student.Nazwisko}: {student.SredniaOcen:F2}");
        }

        // Zadanie 4
        private void Zadanie4()
        {
            // Tworzenie obiektów i wykonywanie prostych operacji matematycznych
            Licz liczba1 = new Licz(10);
            liczba1.Dodaj(5);
            liczba1.Odejmij(3);
            liczba1.WypiszStan();

            Licz liczba2 = new Licz(20);
            liczba2.Odejmij(7);
            liczba2.WypiszStan();
        }

        // Zadanie 5
        private void Zadanie5()
        {
            // Przykładowa tablica liczb
            int[] dane = { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Tworzenie obiektu klasy Sumator
            Sumator sumator = new Sumator(dane);

            // Wywołania metod klasy
            Console.WriteLine($"Suma wszystkich liczb: {sumator.Suma()}");
            Console.WriteLine($"Suma liczb podzielnych przez 2: {sumator.SumaPodziel2()}");
            Console.WriteLine($"Ilość elementów w tablicy: {sumator.IleElementow()}");

            sumator.WypiszElementy();
            sumator.WypiszZakres(2, 6);
        }
    }

    // Zadanie 1
    class Osoba
    {
        private string imie;
        private string nazwisko;
        private int wiek;

        // Konstruktor inicjujący pola
        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }

        // Właściwości z prostą walidacją danych
        public string Imie
        {
            get => imie;
            set
            {
                if (value.Length >= 2)
                    imie = value;
                else
                    imie = "Nieznane";
            }
        }

        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                if (value.Length >= 2)
                    nazwisko = value;
                else
                    nazwisko = "Nieznane";
            }
        }

        public int Wiek
        {
            get => wiek;
            set
            {
                if (value > 0)
                    wiek = value;
                else
                    wiek = 1;
            }
        }

        // Metoda wyświetlająca dane o osobie
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Osoba: {Imie} {Nazwisko}, Wiek: {Wiek}");
        }
    }

    // Zadanie 2
    class BankAccount
    {
        private decimal saldo;
        public string Wlasciciel { get; private set; }

        // Konstruktor inicjujący właściciela i saldo
        public BankAccount(string wlasciciel, decimal saldoPoczatkowe)
        {
            Wlasciciel = wlasciciel;
            saldo = saldoPoczatkowe;
        }

        // Właściwość tylko do odczytu
        public decimal Saldo => saldo;

        // Metoda wpłaty pieniędzy
        public void Wplata(decimal kwota)
        {
            if (kwota > 0)
            {
                saldo += kwota;
                Console.WriteLine($"Wpłacono {kwota} zł");
            }
            else
            {
                Console.WriteLine("Kwota musi być dodatnia.");
            }
        }

        // Metoda wypłaty pieniędzy
        public void Wyplata(decimal kwota)
        {
            if (kwota > 0 && kwota <= saldo)
            {
                saldo -= kwota;
                Console.WriteLine($"Wypłacono {kwota} zł");
            }
            else
            {
                Console.WriteLine("Brak środków lub niepoprawna kwota.");
            }
        }
    }

    // Zadanie 3
    class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        private int[] oceny = new int[0]; 

        // Konstruktor przypisujący imię i nazwisko
        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        // Metoda dodająca ocenę do tablicy
        public void DodajOcene(int ocena)
        {
            if (ocena >= 2 && ocena <= 5)
            {
                Array.Resize(ref oceny, oceny.Length + 1);
                oceny[oceny.Length - 1] = ocena;
            }
            else
            {
                Console.WriteLine("Nieprawidłowa ocena (dopuszczalne 2–5).");
            }
        }

      
        public double SredniaOcen
        {
            get
            {
                if (oceny.Length == 0) return 0;
                double suma = 0;
                foreach (int o in oceny) suma += o;
                return suma / oceny.Length;
            }
        }
    }

    // Zadanie 4
    class Licz
    {
        private int value; // prywatne pole przechowujące wartość liczbową

        // Konstruktor z parametrem
        public Licz(int value)
        {
            this.value = value;
        }

        // Dodaje wartość do pola
        public void Dodaj(int liczba)
        {
            value += liczba;
        }

        // Odejmuje wartość od pola
        public void Odejmij(int liczba)
        {
            value -= liczba;
        }

        // Wypisuje aktualny stan obiektu
        public void WypiszStan()
        {
            Console.WriteLine($"Aktualna wartość: {value}");
        }
    }

    // Zadanie 5
    class Sumator
    {
        private int[] Liczby;

        // Konstruktor przyjmujący tablicę liczb
        public Sumator(int[] liczby)
        {
            Liczby = liczby;
        }

        // Zwraca sumę wszystkich elementów
        public int Suma()
        {
            int suma = 0;
            foreach (int l in Liczby) suma += l;
            return suma;
        }

        // Zwraca sumę liczb podzielnych przez 2
        public int SumaPodziel2()
        {
            int suma = 0;
            foreach (int l in Liczby)
            {
                if (l % 2 == 0)
                    suma += l;
            }
            return suma;
        }

        // Zwraca ilość elementów w tablicy
        public int IleElementow()
        {
            return Liczby.Length;
        }

        // Wypisuje wszystkie liczby
        public void WypiszElementy()
        {
            Console.WriteLine("Elementy tablicy: " + string.Join(", ", Liczby));
        }

        // Wypisuje elementy z zakresu indeksów
        public void WypiszZakres(int lowIndex, int highIndex)
        {
            Console.Write("Zakres [" + lowIndex + ", " + highIndex + "]: ");

            for (int i = 0; i < Liczby.Length; i++)
            {
                if (i >= lowIndex && i <= highIndex)
                {
                    Console.Write(Liczby[i] + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
