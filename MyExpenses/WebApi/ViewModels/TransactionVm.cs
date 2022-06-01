namespace WebApi.ViewModels
{
    public class TransactionVm
    {
        public double Amount { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public TransactionVm(double amount, string title, DateTime date)
        {
            Amount = amount;
            Title = title;
            Date = date;
        }
    }
}

