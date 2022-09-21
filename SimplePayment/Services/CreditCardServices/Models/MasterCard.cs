using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePayment.Services.CreditCardServices.Models
{
    public class MasterCard: CreditCard
    {
        public MasterCard(CreditCard creditCard) : base(creditCard)
        {
        }
        public override string GetName() => CreditCardType.MasterCard;

        public override bool IsCVCValid()
        {
            return CVC.ToString().Length == 3;
        }
    }
}
