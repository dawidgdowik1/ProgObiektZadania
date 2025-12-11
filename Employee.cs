using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public IContract Contract { get; private set; }

        public Employee(string FirstName, string LastName) : this(FirstName, LastName, new Internship()) { }

        public Employee(string firstName, string lastName, IContract contract)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentNullException(nameof(firstName))
                : firstName;

            LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentNullException(nameof(lastName))
                : lastName;

            Contract = contract ?? throw new ArgumentNullException(nameof(contract));
        }

        public void ZmienKontrakt(IContract nowyKontrakt)
        {
            if (nowyKontrakt != null)
            {
                Contract = nowyKontrakt;
            }
        }

        public decimal Pensja() => Contract.Salary();

        public override string ToString()
        {
            return $"Pracownik: {FirstName} {LastName}\n" +
                   $"Aktualna pensja: {Pensja():C}\n" +
                   $"Detale kontraktu: {Contract.ToString()}";
        }
    }
}