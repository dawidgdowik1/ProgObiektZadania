using System.Collections.Generic;

public interface IContactRepository
{
    List<Contact> GetAll();
    void SaveAll(List<Contact> contacts);
}
