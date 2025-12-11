namespace ConsoleApp1
{
    public class Internship : IContract
    {
        public decimal StawkaMiesieczna { get; }

        public Internship() : this(1000m) { }

        public Internship(decimal stawkaMiesieczna)
        {
            StawkaMiesieczna = stawkaMiesieczna;
        }

        public decimal Salary()
        {
            return StawkaMiesieczna;
        }

        public override string ToString()
        {
            return $"Umowa: Staż (Stawka: {StawkaMiesieczna:C})";
        }
    }
}