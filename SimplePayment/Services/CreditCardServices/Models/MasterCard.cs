namespace SimplePayment.Services.CreditCardServices.Models
{
    public class MasterCard: CreditCard
    {
        public MasterCard(CreditCard creditCard) : base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.MasterCard;
        public override bool IsCVCValid() => CVC.ToString().Length == 3;
    }
}
