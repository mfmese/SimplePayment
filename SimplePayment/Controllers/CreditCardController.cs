﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplePayment.Controllers.Models;
using SimplePayment.Services.CreditCardServices;
using SimplePayment.Services.CreditCardServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePayment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ILogger<CreditCardController> logger, ICreditCardService creditCardService)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public ValidateCreditCardResponse ValidateCreditCard([FromQuery] ValidateCreditCardRequest request)
        {
            var issueDate = new IssueDate(request.IssueDateYear, request.IssueDateMonth);
            var creditCard = new CreditCard(request.CardOwner, request.CardNumber, issueDate, request.CVC);
            var response = _creditCardService.Validate(creditCard);
            return new ValidateCreditCardResponse(response);
        }
    }
}
