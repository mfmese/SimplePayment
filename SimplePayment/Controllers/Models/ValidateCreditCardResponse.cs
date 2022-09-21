using SimplePayment.Services.CreditCardServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
