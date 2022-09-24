using SimplePayment.Services.CreditCardServices;
using System.Collections.Generic;

namespace SimplePayment.Controllers.Models
{
    public class ValidateCreditCardResponse
    {
        public ValidateCreditCardResponse(CreditCardValidatePaymentResponse creditCardResponse)
        {
            CreditCardType = creditCardResponse.CreditCardType;
            ValidationErrors = creditCardResponse.ValidationErrors;
        }

        public string CreditCardType { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
