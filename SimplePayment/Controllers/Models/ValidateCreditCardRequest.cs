namespace SimplePayment.Controllers.Models
{
    public class ValidateCreditCardRequest
    {
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string IssueDateYear { get; set; }
        public string IssueDateMonth { get; set; }
        public int? CVC { get; set; }
    }
}
