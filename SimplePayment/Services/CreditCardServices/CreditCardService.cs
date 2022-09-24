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

    public class CreditCardService : ICreditCardService
    {
        public CreditCardValidatePaymentResponse Validate(CreditCard creditCard)
        {
            //Check general validations about credit card such as all fields provided and their types are correct.
            var validationErrors = creditCard.GetValidationResults();

            var isCardNumberNotExists = validationErrors.Any(x => x == ValidationMessages.CardNumberEmpty);
            if (isCardNumberNotExists)
                return new CreditCardValidatePaymentResponse(CreditCardType.NotFoundCreditCard, validationErrors);

            creditCard = CreditCardFactory.Create(creditCard);

            //Return from here when creditCard type not found because if there is no credittype found then cvc and expiredate validation are not necessary to check
            if (creditCard.GetName() == CreditCardType.NotFoundCreditCard)
                return new CreditCardValidatePaymentResponse(CreditCardType.NotFoundCreditCard, validationErrors);

            if (creditCard.IsIssueDateExpired() == true)
                validationErrors.Add(ValidationMessages.CreditCardExpired);

            if (!creditCard.IsCVCValid())
                validationErrors.Add(string.Format(ValidationMessages.CVCNotValid, creditCard.GetName()));

            return new CreditCardValidatePaymentResponse(creditCard.GetName(), validationErrors);
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


