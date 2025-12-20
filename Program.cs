using System;
using System.Collections.Generic; 

namespace ConsoleApp1
{
    // --- TYPY WYLICZENIOWE (ENUM) ---

    enum Operacja
    {
        Dodawanie = 1,
        Odejmowanie,
        Mnozenie,
        Dzielenie
    }

    enum StatusZamowienia
    {
        Oczekujące,
        Przyjęte,
        Zrealizowane,
        Anulowane
    }

    enum Kolor
    {
        Czerwony,
        Niebieski,
        Zielony,
        Zolty,
        Fioletowy
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --- ZADANIE 1: KALKULATOR I LISTA ---
            Console.WriteLine("=== ZADANIE 1: KALKULATOR ===");
            List<double> historia = new List<double>(); 

            try
            {
                Console.Write("Podaj liczbe 1: ");
                double n1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Wybierz operacje (1-Dodaj, 2-Odejmij, 3-Mnozenie, 4-Dzielenie):");
              
                Operacja op = (Operacja)int.Parse(Console.ReadLine());

                Console.Write("Podaj liczbe 2: ");
                double n2 = double.Parse(Console.ReadLine());

                double wynik = 0;
                
                switch (op)
                {
                    case Operacja.Dodawanie:
                        wynik = n1 + n2;
                        break;
                    case Operacja.Odejmowanie:
                        wynik = n1 - n2;
                        break;
                    case Operacja.Mnozenie:
                        wynik = n1 * n2;
                        break;
                    case Operacja.Dzielenie:
                        if (n2 == 0) throw new DivideByZeroException("Błąd: Dzielenie przez zero.");
                        wynik = n1 / n2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                historia.Add(wynik);
                Console.WriteLine($"Wynik operacji: {wynik}");
                Console.WriteLine("Historia (List): " + string.Join(", ", historia));
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Nieprawidłowy format danych wejściowych.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

         
            Console.ReadKey();


            // --- ZADANIE 2: SŁOWNIK I ZAMÓWIENIA ---
            Console.WriteLine("\n=== ZADANIE 2: ZARZADZANIE ZAMOWIENIAMI ===");
           
            Dictionary<int, List<string>> zamowienia = new Dictionary<int, List<string>>();
            Dictionary<int, StatusZamowienia> statusy = new Dictionary<int, StatusZamowienia>();

            // Dodanie testowego zamówienia
            zamowienia.Add(101, new List<string> { "Chleb", "Mleko", "Maslo" });
            statusy.Add(101, StatusZamowienia.Oczekujące);

            Console.WriteLine("Zamowienie 101 produkty: " + string.Join(", ", zamowienia[101]));

            try
            {
                Console.Write("Podaj numer zamówienia do zmiany statusu: ");
                int nr = int.Parse(Console.ReadLine());

                if (!statusy.ContainsKey(nr))
                    throw new KeyNotFoundException("Błąd: Nie odnaleziono zamówienia o tym numerze.");

                Console.WriteLine("Wybierz status (0-Oczekujace, 1-Przyjete, 2-Zrealizowane, 3-Anulowane):");
                StatusZamowienia nowy = (StatusZamowienia)int.Parse(Console.ReadLine());

                if (statusy[nr] == nowy)
                    throw new ArgumentException("Błąd: Próba zmiany na ten sam status.");

                statusy[nr] = nowy;
                Console.WriteLine($"Status zamówienia {nr} zmieniony na {statusy[nr]}.");
            }
            catch (Exception ex)
            {
                // Ogólna obsługa błędów zgodnie z sekcją o wielu wyjątkach
                Console.WriteLine($"Wystapił blad: {ex.Message}");
            }

           
            Console.ReadKey();


            // --- ZADANIE 3: GRA I LOSOWANIE ---
            Console.WriteLine("\n=== ZADANIE 3: ZGADYWANIE KOLORU ===");
            List<Kolor> dostepneKolory = new List<Kolor> { Kolor.Czerwony, Kolor.Niebieski, Kolor.Zielony, Kolor.Zolty, Kolor.Fioletowy };

            Random r = new Random();
            Kolor wylosowany = dostepneKolory[r.Next(dostepneKolory.Count)];

            bool trafione = false;
            while (!trafione)
            {
                try
                {
                    Console.Write("Zgadnij kolor (Czerwony, Niebieski, Zielony, Zolty, Fioletowy): ");
                    string wejscie = Console.ReadLine();

                   
                    if (!Enum.TryParse(wejscie, true, out Kolor zgadywany) || !Enum.IsDefined(typeof(Kolor), zgadywany))
                    {
                        throw new ArgumentException("Nieprawidłowy argument - tego koloru nie ma na liście.");
                    }

                    if (zgadywany == wylosowany)
                    {
                        Console.WriteLine("Brawo! To ten kolor.");
                        trafione = true;
                    }
                    else
                    {
                        Console.WriteLine("Pudło! Próbuj dalej.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nProgram zakończył działanie.");
            Console.ReadKey();
        }
    }
}