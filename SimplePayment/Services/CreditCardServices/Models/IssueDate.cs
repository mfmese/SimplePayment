namespace SimplePayment.Services.CreditCardServices.Models
{
    public class IssueDate
    {
        public IssueDate(string year, string month)
        {
            Year = year;
            Month = month;
        }

        public string Year { get; set; }
        public string Month { get; set; }
    }
}
