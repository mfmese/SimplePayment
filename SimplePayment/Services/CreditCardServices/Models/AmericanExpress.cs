using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePayment.Services.CreditCardServices.Models
{
    public class AmericanExpress : CreditCard
    {
        public AmericanExpress(CreditCard creditCard) : base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.AmericanExpress;

        public override bool IsCVCValid()
        {
            return CVC.ToString().Length == 4;
        }
    }
}
