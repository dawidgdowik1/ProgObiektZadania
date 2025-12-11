namespace ConsoleApp1
{
    public class Position : IContract
    {
        public decimal MonthlyRate { get; }
        public decimal Overtime { get; }

        public Position(decimal monthlyRate, decimal overtime)
        {
            MonthlyRate = monthlyRate;
            Overtime = overtime;
        }

        public decimal Salary()
        {
            decimal overtimePay = Overtime * (MonthlyRate / 60m);
            return MonthlyRate + overtimePay;
        }

        public override string ToString()
        {
            return $"Umowa: Etat (Podstawa: {MonthlyRate:C}, Nadgodziny: {Overtime}, Pensja: {Salary():C})";
        }
    }
}
