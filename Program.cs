class Program
{
    static void Main(string[] args)
    {

        IContactRepository repository = new TxtContactRepository();
        List<Contact> contacts = repository.GetAll();

        while (true)
        {
            Console.WriteLine("\n--- SYSTEM ZARZ¥DZANIA KONTAKTAMI ---");
            Console.WriteLine("1. Wyœwietl wszystkie kontakty");
            Console.WriteLine("2. Dodaj nowy kontakt");
            Console.WriteLine("3. Zapisz i wyjdŸ");
            Console.Write("Wybierz opcjê: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nLista kontaktów:");
                    contacts.ForEach(c => Console.WriteLine(c));
                    break;
                case "2":
                    Console.Write("Podaj ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Podaj Imiê i Nazwisko: ");
                    string name = Console.ReadLine();
                    Console.Write("Podaj Email: ");
                    string email = Console.ReadLine();

                    contacts.Add(new Contact { Id = id, Name = name, Email = email });
                    Console.WriteLine("Dodano kontakt.");
                    break;
                case "3":
                    repository.SaveAll(contacts);
                    Console.WriteLine("Dane zapisane. Do widzenia!");
                    return;
                default:
                    Console.WriteLine("Nieprawid³owa opcja.");
                    break;
            }
        }
    }
}