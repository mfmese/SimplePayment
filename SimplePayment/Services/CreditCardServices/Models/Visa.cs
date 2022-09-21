using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePayment.Services.CreditCardServices.Models
{
    public class Visa: CreditCard
    {
        public Visa(CreditCard creditCard): base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.Visa;
        public override bool IsCVCValid()
        {
            return CVC.ToString().Length == 3;
        }

    }
}
