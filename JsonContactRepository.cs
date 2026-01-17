using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonContactRepository : IContactRepository
{
    private readonly string _filePath = "contacts.json";
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

    public List<Contact> GetAll()
    {
        if (!File.Exists(_filePath)) return new List<Contact>();
        string jsonString = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Contact>>(jsonString) ?? new List<Contact>();
    }

    public void SaveAll(List<Contact> contacts)
    {
        string jsonString = JsonSerializer.Serialize(contacts, _options);
        File.WriteAllText(_filePath, jsonString);
    }
}