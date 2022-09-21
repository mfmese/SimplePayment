using System.Text.RegularExpressions;

namespace SimplePayment.Services.CreditCardServices.Models
{
    public static class CreditCardFactory
    {
        public static CreditCard Create(CreditCard creditCard)
        {
            var regVisa = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
            if (regVisa.IsMatch(creditCard.CardNumber))
                return new Visa(creditCard);

            var regExpress = new Regex("^3[47][0-9]{13}$");
            if (regExpress.IsMatch(creditCard.CardNumber))
                return new AmericanExpress(creditCard);

            var regMaster = new Regex("^5[1-5][0-9]{14}$");
            if (regMaster.IsMatch(creditCard.CardNumber))
                return new MasterCard(creditCard);

            return new NotFoundCreditCard(creditCard);
        }
    }
}
