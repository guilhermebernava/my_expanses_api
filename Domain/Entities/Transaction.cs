namespace Domain.Entities;

public class Transaction : Entity
{
    public double Amount { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }

    public Transaction(double amount, string title, DateTime date) : base()
    {
        Amount = amount;
        Title = title;
        Date = date;
    }
}

