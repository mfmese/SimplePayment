namespace SimplePayment.Services.CreditCardServices.Models
{
    public class AmericanExpress : CreditCard
    {
        public AmericanExpress(CreditCard creditCard) : base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.AmericanExpress;
        public override bool IsCVCValid() => CVC.ToString().Length == 4;
    }
}
