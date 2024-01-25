using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paytabs.PaymentProcessor;
using Paytabs.PaymentProcessor.Contracts;
using Paytabs.PaymentProcessor.Infrastructure;
using Paytabs.PaymentProcessor.Models;

namespace UI
{
    public class IndexModel : PageModel
    {
        private readonly IPaytabsPaymentProcessor paytabsPaymentProcessor;
        public string? value { get; set; }

        public IndexModel(IPaytabsPaymentProcessor paytabsPaymentProcessor)
        {
            this.paytabsPaymentProcessor = paytabsPaymentProcessor;
        }

        public async Task<IActionResult> OnGet()
        {
            /*var createPaymentRequest = new CreatePaymentRequest
            {
                ReturnUrl = "https://localhost:7053/",
                Description = "test desc",
                MerchantOrderReferenceKey = new Random().Next(100000,999999).ToString(),
                CustomerInfo = new CustomerInfo { 
                    FirstName = "Mo",
                    LastName = "Omran",
                    Email = "mohammedomran9512@gmail.com",
                    Phone = "01234567890"
                },
                PaymentInfo = new PaymentInfo
                {
                    CurrencyThreeLetterCode = "SAR",
                    Total = 50
                },
                TransactionType = TransactionType.ecom,
                TransactionClass = TransactionClass.sale,
            };

            var result = await paytabsPaymentProcessor.CreatePaymentRequest(createPaymentRequest, new CancellationToken());
            if (result.IsSuccess)
                return Redirect(result.Value.RedirectUrl);

            value = result.Error;*/

            //var queryPaymentResult = await paytabsPaymentProcessor.QueryPayment("TST2402500839032", new CancellationToken());
            return Page();
        }
    }
}