using SimplePayment.Services.CreditCardServices.Models;
using SimplePayment.Validations;
using System.Collections.Generic;
using System.Linq;

namespace SimplePayment.Services.CreditCardServices
{
    public interface ICreditCardService
    {
        CreditCardValidatePaymentResponse Validate(CreditCard creditCard);
    }
    public class CreditCardService: ICreditCardService
    {
        public CreditCardValidatePaymentResponse Validate(CreditCard creditCard)
        {
            var validationErrors = creditCard.GetValidationResults();

            var isCardNumberNotExists = validationErrors.Any(x => x == ValidationMessages.CardNumberEmpty);
            if (isCardNumberNotExists)
                return new CreditCardValidatePaymentResponse(CreditCardType.NotFoundCreditCard , validationErrors);

            var card = CreditCardFactory.Create(creditCard);

            if (card.GetName() == CreditCardType.NotFoundCreditCard)
                return new CreditCardValidatePaymentResponse(CreditCardType.NotFoundCreditCard, validationErrors);

            if (card.IsIssueDateExpired() == true)
                validationErrors.Add(ValidationMessages.CreditCardExpired);

            if (!card.IsCVCValid())
                validationErrors.Add(string.Format(ValidationMessages.CVCNotValid,card.GetName()));  

            return new CreditCardValidatePaymentResponse(card.GetName(), validationErrors);
        }
    
    }

    public class CreditCardValidatePaymentResponse
    {
        public CreditCardValidatePaymentResponse(string creditCardType, List<string> validationErrors)
        {
            CreditCardType = creditCardType;
            ValidationErrors = validationErrors;
        }

        public string CreditCardType { get; set; }
        public List<string> ValidationErrors { get; set; }        
    }
}


