using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    // =================================================================
    // ZADANIE 1: 
    // =================================================================
    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"Rysowanie ogólnej figury ({X},{Y}).");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine($"Rysowanie prostokąta o wymiarach {Width}x{Height}.");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rysowanie trójkąta.");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rysowanie koła.");
        }
    }
   

    // =================================================================
    // ZADANIE 2
    // =================================================================

    
    public static class PeselHelper
    {
        
        public static int GetAge(string pesel)
        {
            if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11) return -1;
            int rok = int.Parse(pesel.Substring(0, 2));
            int miesiac = int.Parse(pesel.Substring(2, 2));

            
            if (miesiac > 20) rok += 2000;
            else rok += 1900;

            DateTime dataUrodzenia = new DateTime(rok, miesiac % 20, int.Parse(pesel.Substring(4, 2)));
            int wiek = DateTime.Now.Year - dataUrodzenia.Year;
            if (DateTime.Now < dataUrodzenia.AddYears(wiek)) wiek--;
            return wiek;
        }

      
        public static string GetGender(string pesel)
        {
            if (string.IsNullOrWhiteSpace(pesel) || pesel.Length != 11) return "Nieznana";
            int plec = int.Parse(pesel.Substring(9, 1));
            return (plec % 2 == 0) ? "Kobieta" : "Mężczyzna";
        }
    }

    // Klasa wirtualna Osoba
    public abstract class Osoba
    {
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Pesel { get; set; } = string.Empty;

       
        public void SetFirstName(string imie) => Imie = imie;
        public void SetLastName(string nazwisko) => Nazwisko = nazwisko;
        public void SetPesel(string pesel) => Pesel = pesel;
        public int GetAge() => PeselHelper.GetAge(Pesel);
        public string GetGender() => PeselHelper.GetGender(Pesel);
        public string GetFullName() => $"{Imie} {Nazwisko}";

        
        public abstract string GetEducationInfo();
        public abstract bool CanGoAloneToHome();
    }

    // Klasa Uczen
    public class Uczen : Osoba
    {
        public string Szkola { get; set; } = string.Empty;
        public bool MozeSamWracacDoDomu { get; set; } = false;

        public void SetSchool(string szkola) => Szkola = szkola;
        public void ChangeSchool(string nowaSzkola) => Szkola = nowaSzkola;
        public void SetCanGoHomeAlone(bool moze) => MozeSamWracacDoDomu = moze;

        public override string GetEducationInfo() => $"Uczeń w szkole: {Szkola}";

        
        public override bool CanGoAloneToHome()
        {
            return GetAge() >= 12 || MozeSamWracacDoDomu;
        }

        // Metoda Info
        public string Info()
        {
            string status = CanGoAloneToHome() ? "może" : "musi";
            return $"{GetFullName()} (Wiek: {GetAge()}) {status} wracać sam/a do domu.";
        }
    }

    // Klasa Nauczyciel
    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; set; } = "Mgr";
        public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

        public override string GetEducationInfo() => $"{TytulNaukowy}, Nauczyciel w szkole: {Szkola}";

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine($"\n--- Uczniowie (Stan na: {dateToCheck.ToShortDateString()}) ---");
            Console.WriteLine("Mogą wracać sami:");

            var uczniowieSamodzielni = PodwladniUczniowie
                .Where(u => u.CanGoAloneToHome())
                .ToList();

            if (uczniowieSamodzielni.Any())
            {
                foreach (var uczen in uczniowieSamodzielni)
                {
                    Console.WriteLine($"- {uczen.Nazwisko} (Wiek: {uczen.GetAge()})");
                }
            }
            else
            {
                Console.WriteLine("- Brak.");
            }
        }
    }
    

    // =================================================================
    // ZADANIE 3: 
    // =================================================================

   
    public interface IOsoba
    {
        string Imie { get; set; }
        string Nazwisko { get; set; }
        string ZwrocPelnaNazwe();
    }

    // 3a. Klasa Osoba dziedzicząca po IOsoba
    public class Osoba3a : IOsoba
    {
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";
        public override string ToString() => ZwrocPelnaNazwe();
    }

    // 3d. Interfejs IStudent
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        int Rok { get; set; }
        string Semestr { get; set; }
    }

    // 3d. Klasa Student implementująca IStudent
    public class Student : IStudent
    {
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Uczelnia { get; set; } = string.Empty;
        public string Kierunek { get; set; } = string.Empty;
        public int Rok { get; set; }
        public string Semestr { get; set; } = string.Empty;

        public string ZwrocPelnaNazwe() => $"{Imie} {Nazwisko}";

        public string WypiszPelnaNazweIUczelnie()
        {
            return $"{ZwrocPelnaNazwe()} – {Rok}{Kierunek} {Uczelnia}";
        }

        public override string ToString() => WypiszPelnaNazweIUczelnie();
    }

    // 3e. Klasa StudentWSIiZ
    public class StudentWSIiZ : Student
    {
        public StudentWSIiZ(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Uczelnia = "WSIiZ"; 
            Kierunek = "IID-P";
            Rok = 4;
            Semestr = "Zimowy";
        }
    }

    
    public static class OsobaExtensions
    {
        // 3b. Metoda rozszerzająca 
        public static void WypiszOsoby(this List<IOsoba> listaOsob)
        {
            Console.WriteLine("\n--- Metoda rozszerzająca: Wypisanie Osób ---");
            foreach (var osoba in listaOsob)
            {
                Console.WriteLine($"- {osoba.ZwrocPelnaNazwe()}");
            }
        }

        // 3c. Metoda rozszerzająca List<IOsoba> void PosortujOsobyPoNazwisku()
        public static void PosortujOsobyPoNazwisku(this List<IOsoba> listaOsob)
        {
            listaOsob.Sort((a, b) => a.Nazwisko.CompareTo(b.Nazwisko));
        }

        // 3e. Przeciążenie metody rozszerzającej dla List<StudentWSIiZ>
        public static void WypiszOsoby(this List<StudentWSIiZ> listaStudentow)
        {
            Console.WriteLine("\n--- Przeciążona metoda rozszerzająca dla StudentWSIiZ ---");
            foreach (var student in listaStudentow)
            {
                Console.WriteLine($"- {student.WypiszPelnaNazweIUczelnie()}");
            }
        }
    }

    // Klasa testująca 
    public class TasksLab4
    {
        public void Run()
        {
            Console.WriteLine("\n\n=============================================");
            Console.WriteLine("LAB 4: ZADANIA 1,2,3");
            Console.WriteLine("=============================================");

            // --- TEST ZADANIA 1  ---
            Console.WriteLine("\n--- TEST ZADANIA 1: Polimorfizm Klas Wirtualnych (Shape) ---");
            List<Shape> figury = new List<Shape>
            {
                new Rectangle { Width = 10, Height = 5 },
                new Triangle(),
                new Circle()
            };

            foreach (var figura in figury)
            {
                figura.Draw(); // Polimorfizm w działaniu
            }

            // TEST ZADANIA 2 
            Console.WriteLine("\n--- TEST ZADANIA 2: Dziedziczenie i Wiek (Nauczyciel/Uczeń) ---");

           
           
            Uczen mlodyUczen = new Uczen { Imie = "Marek", Nazwisko = "Kowalski", Pesel = "15011500000", Szkola = "SP nr 1" };
            mlodyUczen.SetCanGoHomeAlone(false); // Brak pozwolenia

            
            Uczen starszyUczen = new Uczen { Imie = "Anna", Nazwisko = "Nowak", Pesel = "10011500000", Szkola = "SP nr 1" };
            starszyUczen.SetCanGoHomeAlone(false); // Brak pozwolenia

            Console.WriteLine(mlodyUczen.Info());
            Console.WriteLine(starszyUczen.Info());

            // Test Nauczyciela
            Nauczyciel nauczyciel = new Nauczyciel { Imie = "Piotr", Nazwisko = "Wiewiór", Szkola = "SP nr 1" };
            nauczyciel.PodwladniUczniowie.Add(mlodyUczen);
            nauczyciel.PodwladniUczniowie.Add(starszyUczen);

           
            nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);

            // --- TEST ZADANIA 3 
            Console.WriteLine("\n--- TEST ZADANIA 3: Metody Rozszerzające (IOsoba, IStudent) ---");

            // 3a. Lista IOsoba
            List<IOsoba> osoby = new List<IOsoba>
            {
                new Osoba3a { Imie = "Alicja", Nazwisko = "Zając" },
                new Osoba3a { Imie = "Bartosz", Nazwisko = "Kowalski" },
                new Osoba3a { Imie = "Celina", Nazwisko = "Adamczyk" }
            };

            // 3b. Wypisanie
            osoby.WypiszOsoby();

            // 3c. Sortowanie i ponowne wypisanie
            osoby.PosortujOsobyPoNazwisku();
            Console.WriteLine("\n--- Wypisanie po posortowaniu po Nazwisku ---");
            osoby.WypiszOsoby();

            // 3e. Test przeciążonej metody dla StudentWSIiZ
            List<StudentWSIiZ> studenci = new List<StudentWSIiZ>
            {
                new StudentWSIiZ("Marcin", "Testowy"),
                new StudentWSIiZ("Magda", "Przykladowa")
            };

            studenci.WypiszOsoby(); // Wywołuje przeciążoną metodę
        }
    }
}
