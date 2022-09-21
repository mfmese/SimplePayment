using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePayment.Validations
{
    public static class ValidationMessages
    {
        public const string CreditCardExpired = "credit card is expired";
        public const string CVCNotValid = "CVC is not valid for the {0}";
        public const string CardOwnerEmpty = "Card Owner field is null or empty";
        public const string CardNumberEmpty = "Card Number field is null or empty";
        public const string CVCEmpty = "CVC field is null or empty";
        public const string IssueDateEmpty = "Issue Date field is null or empty";
        public const string IssueDateYearNotValid = "Issue Date Year field is not valid";
        public const string IssueDateMonthNotValid = "Issue Date Month field is not valid";
    }
}
