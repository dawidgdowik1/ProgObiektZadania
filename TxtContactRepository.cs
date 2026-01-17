using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TxtContactRepository : IContactRepository
{
    private readonly string _filePath = "contacts.txt";

    public List<Contact> GetAll()
    {
        var contacts = new List<Contact>();
        if (!File.Exists(_filePath)) return contacts;

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 3)
            {
                contacts.Add(new Contact
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Email = parts[2]
                });
            }
        }
        return contacts;
    }

    public void SaveAll(List<Contact> contacts)
    {
        var lines = contacts.Select(c => $"{c.Id};{c.Name};{c.Email}");
        File.WriteAllLines(_filePath, lines);
    }
}