namespace SimplePayment.Services.CreditCardServices.Models
{
    public class NotFoundCreditCard : CreditCard
    {
        public NotFoundCreditCard(CreditCard creditCard): base(creditCard)
        {

        }
        public override string GetName()
        {
            return CreditCardType.NotFoundCreditCard;
        }

        public override bool IsCVCValid()
        {
            return false;
        }
    }
}
