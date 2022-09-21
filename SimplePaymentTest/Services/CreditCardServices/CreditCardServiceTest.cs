using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplePayment.Services.CreditCardServices;
using SimplePayment.Services.CreditCardServices.Models;
using SimplePayment.Validations;
using System;
using System.Linq;

namespace SimplePaymentTest.Services.CreditCardServices
{
    [TestClass]
    public class CreditCardServiceTest
    {
        private CreditCardService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new CreditCardService();
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnMasterCard()
        {
            var creditCard = new CreditCard("Mehmet", "5555555555554444", new IssueDate("26", "01"), 344);

            var response = _service.Validate(creditCard);

            Assert.AreEqual(response.CreditCardType, CreditCardType.MasterCard);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnAmericanExpress()
        {
            var creditCard = new CreditCard("Fethi", "378282246310005", new IssueDate("26", "01"), 3444);

            var response = _service.Validate(creditCard);

            Assert.AreEqual(response.CreditCardType, CreditCardType.AmericanExpress);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnVisa()
        {
            var creditCard = new CreditCard("Fethi", "4012888888881881", new IssueDate("26", "01"), 3444);

            var response = _service.Validate(creditCard);

            Assert.AreEqual(response.CreditCardType, CreditCardType.Visa);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnNotFoundCreditCard()
        {
            var creditCard = new CreditCard("Fethi", "111111", new IssueDate("26", "01"), 3444);

            var response = _service.Validate(creditCard);

            Assert.AreEqual(response.CreditCardType, CreditCardType.NotFoundCreditCard);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnCreditCardExpired()
        {
            var creditCard = new CreditCard("Fethi", "111111", new IssueDate("21", "01"), 3444);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.CreditCardExpired);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnCvcNotValid()
        {
            var creditCard = new CreditCard("Fethi", "111111", new IssueDate("26", "01"), 44);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x=> x == string.Format(ValidationMessages.CVCNotValid, response.CreditCardType));

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnCardOwnerEmpty()
        {
            var creditCard = new CreditCard("", "111111", new IssueDate("26", "01"), 44);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.CardOwnerEmpty);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnCardNumberEmpty()
        {
            var creditCard = new CreditCard("Mehmet", null, new IssueDate("26", "01"), 44);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.CardNumberEmpty);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnCVCEmpty()
        {
            var creditCard = new CreditCard("Mehmet", null, new IssueDate("26", "01"), null);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.CVCEmpty);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnIssueDateEmpty()
        {
            var creditCard = new CreditCard("Mehmet", null, null, null);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.IssueDateEmpty);

            Assert.IsTrue(isExists);
        }


        [TestMethod]
        public void Validate_CreditCardInputs_ReturnIssueDateYearNotValid()
        {
            var creditCard = new CreditCard("Mehmet", null, new IssueDate("aa","21"), null);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.IssueDateYearNotValid);

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Validate_CreditCardInputs_ReturnIssueDateMonthNotValid()
        {
            var creditCard = new CreditCard("Mehmet", null, new IssueDate("aa", "bb"), null);

            var response = _service.Validate(creditCard);

            var isExists = response.ValidationErrors.Any(x => x == ValidationMessages.IssueDateMonthNotValid);

            Assert.IsTrue(isExists);
        }
    }
}
