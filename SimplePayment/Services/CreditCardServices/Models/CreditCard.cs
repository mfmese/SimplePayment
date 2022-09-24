using SimplePayment.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePayment.Services.CreditCardServices.Models
{
    public class CreditCard
    {
        public CreditCard(CreditCard creditCard)
        {
            CardOwner = creditCard.CardOwner;
            CardNumber = creditCard.CardNumber;
            IssueDate = creditCard.IssueDate;
            IssueDate.Year = creditCard.IssueDate.Year;
            IssueDate.Month = creditCard.IssueDate.Month;
            CVC = creditCard.CVC;
        }

        public CreditCard(string cardOwner, string cardNumber, IssueDate issueDate, int? cVC)
        {
            CardOwner = cardOwner;
            CardNumber = cardNumber;
            IssueDate = issueDate;
            CVC = cVC;
        }

        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public IssueDate IssueDate { get; set; }
        public int? CVC { get; set; }

        public virtual string GetName() => "";
        public virtual bool IsCVCValid() => false;

        public bool? IsIssueDateExpired(DateTime? now = null)
        {
            try
            {
                var issueYear = Convert.ToInt32(IssueDate.Year);
                var issueMonth = Convert.ToInt32(IssueDate.Month);

                now = now ?? DateTime.Now;
                var nowYear = now?.Year;

                if (IssueDate.Year.Length == 2)
                {
                    var nowYearStr = nowYear.ToString();
                    nowYearStr = nowYearStr.Substring(nowYearStr.Length - 2);
                    nowYear = Convert.ToInt32(nowYearStr);
                }

                if (issueYear < nowYear || (issueYear == nowYear && (issueMonth < now?.Month)))
                    return true;

                return false;
            }
            catch (Exception)
            {
                return null;
            }  
        }

        public List<string> GetValidationResults()
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(CardOwner))
                validationErrors.Add(ValidationMessages.CardOwnerEmpty);

            if (string.IsNullOrEmpty(CardNumber))
                validationErrors.Add(ValidationMessages.CardNumberEmpty);

            if (CVC == null || CVC == 0)
                validationErrors.Add(ValidationMessages.CVCEmpty);

            if (IssueDate == null || string.IsNullOrEmpty(IssueDate.Month) || string.IsNullOrEmpty(IssueDate.Year))
                validationErrors.Add(ValidationMessages.IssueDateEmpty);

            if(IssueDate != null && !IsNumeric(IssueDate.Year))
                validationErrors.Add(ValidationMessages.IssueDateYearNotValid);

            if (IssueDate != null && !IsNumeric(IssueDate.Month))
                validationErrors.Add(ValidationMessages.IssueDateMonthNotValid);

            return validationErrors;
        }

        private bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}