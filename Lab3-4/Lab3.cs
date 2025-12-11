using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    // =================================================================
    // ZADANIE 1
    // =================================================================

    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Wiek { get; private set; }

        public Person(string firstName, string lastName, int wiek)
        {
            FirstName = firstName;
            LastName = lastName;
            Wiek = wiek;
        }

        public virtual void View()
        {
            Console.WriteLine($"--- Osoba ---");
            Console.WriteLine($"Imię i Nazwisko: {FirstName} {LastName}");
            Console.WriteLine($"Wiek: {Wiek}");
        }
    }

    public class Book
    {
        protected string Title { get; set; }
        protected Person Author { get; set; }
        protected DateTime DataWydania { get; set; }

        public Book(string title, Person author, DateTime dataWydania)
        {
            Title = title;
            Author = author;
            DataWydania = dataWydania;
        }

        public virtual void View()
        {
            Console.WriteLine($"Tytuł: {Title}");
            Console.WriteLine($"Autor: {Author.FirstName} {Author.LastName}");
            Console.WriteLine($"Data Wydania: {DataWydania.ToShortDateString()}");
        }
    }

    public class Reader : Person
    {
        protected List<Book> PrzeczytaneKsiążki { get; set; }

        public Reader(string firstName, string lastName, int wiek)
            : base(firstName, lastName, wiek)
        {
            PrzeczytaneKsiążki = new List<Book>();
        }

        public void AddBook(Book book)
        {
            PrzeczytaneKsiążki.Add(book);
        }

        public void ViewBook()
        {
            if (PrzeczytaneKsiążki.Count == 0) return;

            Console.WriteLine("--- Przeczytane Książki ---");
            foreach (var book in PrzeczytaneKsiążki)
            {
                book.View();
                Console.WriteLine("--------------------------");
            }
        }

        public override void View()
        {
            base.View();
            ViewBook();
        }
    }

    public class Reviewer : Reader
    {
        private static Random Random = new Random();

        public Reviewer(string firstName, string lastName, int wiek)
            : base(firstName, lastName, wiek) { }

        public void Wypisz()
        {
            base.View();

            Console.WriteLine("--- Oceny Recenzenta ---");
            foreach (var book in PrzeczytaneKsiążki)
            {
                int score = Random.Next(1, 11);
                Console.Write($"[Ocena: {score}/10] ");
                book.View();
                Console.WriteLine("--------------------------");
            }
        }
    }

    public class AdventureBook : Book
    {
        protected string Setting { get; set; }

        public AdventureBook(string title, Person author, DateTime dataWydania, string setting)
            : base(title, author, dataWydania) { Setting = setting; }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Typ: Przygodowa (Akcja: {Setting})");
        }
    }

    public class DocumentaryBook : Book
    {
        protected string Subject { get; set; }

        public DocumentaryBook(string title, Person author, DateTime dataWydania, string subject)
            : base(title, author, dataWydania) { Subject = subject; }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Typ: Dokumentalna (Temat: {Subject})");
        }
    }

    // =================================================================
    // KLASA TESTUJĄCA DLA ZADANIA 1
    // =================================================================

    public class TasksLab1
    {
        public void Run()
        {
            Console.WriteLine("\n\n=============================================");
            Console.WriteLine("    ZADANIE 1: TESTOWANIE KLAS BIBLIOTECZNYCH");
            Console.WriteLine("=============================================");

            Person tolkien = new Person("J.R.R.", "Tolkien", 81);
            Person smith = new Person("Jane", "Smith", 45);

            Book book1 = new AdventureBook("Hobbit", tolkien, new DateTime(1937, 9, 21), "Śródziemie");
            Book book2 = new DocumentaryBook("Space Odyssey", smith, new DateTime(2020, 1, 15), "Astronomia");
            Book book3 = new Book("Basic C#", smith, new DateTime(2024, 8, 1));

            Reader czytelnik1 = new Reader("Anna", "Nowak", 22);
            Reviewer recenzent1 = new Reviewer("Piotr", "Zaręba", 30);

            czytelnik1.AddBook(book1);
            czytelnik1.AddBook(book3);
            recenzent1.AddBook(book2);
            recenzent1.AddBook(book3);

            // --- Testy ---
            Console.WriteLine("\n--- Test 1c/1f: Reader.View() i Reviewer.Wypisz() ---");
            czytelnik1.View();
            recenzent1.Wypisz();

            Console.WriteLine("\n--- Test 1d: Polimorfizm Person o = new Reader() ---");
            Person o = new Reader("Tomasz", "Adamski", 28);
            o.View();

            Console.WriteLine("\n--- Test 1g/1j: Lista Person i dynamiczne View ---");
            List<Person> people = new List<Person> { czytelnik1, recenzent1, tolkien };

            foreach (var p in people)
            {
                Console.WriteLine($"\n--- Typ: {p.GetType().Name} ---");
                p.View();
            }
        }
    }

    // =================================================================
    // ZADANIE 2
    // =================================================================

    public class Samochod
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Nadwozie { get; set; }
        public string Kolor { get; set; }
        public int RokProdukcji { get; set; }
        private int _przebieg;

        public int Przebieg
        {
            get { return _przebieg; }
            set { _przebieg = Math.Max(0, value); }
        }

        public Samochod()
        {
            Console.WriteLine("\n--- Tworzenie nowego Samochodu (Użytkownik) ---");
            Console.Write("Marka: "); Marka = Console.ReadLine();
            Console.Write("Model: "); Model = Console.ReadLine();

            Nadwozie = "Sedan"; Kolor = "Czerwony"; RokProdukcji = 2020; Przebieg = 10000;
        }

        public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
        {
            Marka = marka; Model = model; Nadwozie = nadwozie; Kolor = kolor;
            RokProdukcji = rokProdukcji; Przebieg = przebieg;
        }

        public virtual void WyswietlInformacje()
        {
            Console.WriteLine($"\n-- Informacje o Samochodzie --");
            Console.WriteLine($"Marka/Model: {Marka} {Model}");
            Console.WriteLine($"Rok Prod.: {RokProdukcji}, Przebieg: {Przebieg} km");
            Console.WriteLine($"Nadwozie: {Nadwozie}, Kolor: {Kolor}");
        }
    }

    public class SamochodOsobowy : Samochod
    {
        private double _waga;
        private double _pojemnoscSilnika;
        public int IloscOsob { get; set; }

        public double Waga
        {
            get { return _waga; }
            set { _waga = (value >= 2.0 && value <= 4.5) ? value : 2.0; }
        }

        public double PojemnoscSilnika
        {
            get { return _pojemnoscSilnika; }
            set { _pojemnoscSilnika = (value >= 0.8 && value <= 3.0) ? value : 0.8; }
        }

        public SamochodOsobowy() : base()
        {
            Waga = 2.5; PojemnoscSilnika = 1.6; IloscOsob = 5;
        }

        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"-- Szczegóły Osobowe --");
            Console.WriteLine($"Waga: {Waga} t, Pojemność Silnika: {PojemnoscSilnika} L");
            Console.WriteLine($"Ilość Osób: {IloscOsob}");
        }
    }

    // =================================================================
    // (TasksLab2)
    // =================================================================

    public class TasksLab2
    {
        public void Run()
        {
            Console.WriteLine("\n\n=============================================");
            Console.WriteLine("ZADANIE 2");
            Console.WriteLine("=============================================");

            SamochodOsobowy mojOsobowy = new SamochodOsobowy();
            Samochod samochodA = new Samochod();
            Samochod samochodB = new Samochod("Ford", "Focus", "Hatchback", "Szary", 2018, 125000);

            mojOsobowy.WyswietlInformacje();
            samochodA.WyswietlInformacje();
            samochodB.WyswietlInformacje();
        }
    }
}
