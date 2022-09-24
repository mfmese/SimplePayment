namespace SimplePayment.Services.CreditCardServices.Models
{
    public class Visa: CreditCard
    {
        public Visa(CreditCard creditCard): base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.Visa;
        public override bool IsCVCValid() => CVC.ToString().Length == 3;
    }
}
