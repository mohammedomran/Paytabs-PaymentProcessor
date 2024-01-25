using Paytabs.PaymentProcessor.Contracts;
using Paytabs.PaymentProcessor.Infrastructure;
using Paytabs.PaymentProcessor.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Paytabs.PaymentProcessor.Services;

public class PaytabsPaymentProcessor : IPaytabsPaymentProcessor
{
    private readonly string serverKey = PaytabsConfiguration.TestServerKey;
    private readonly long profileId = PaytabsConfiguration.TestProfileId;
    private readonly string paymentRequestEndpoint = Endpoints.PaymentRequestEndpoint;
    private readonly string queryTokenEndpoint = Endpoints.QueryTokenEndpoint;

    public PaytabsPaymentProcessor()
    {
        if (!PaytabsConfiguration.TestMode)
        {

        }
    }

    public async Task<Result<CreatePaymentResponse>> CreatePaymentRequest(CreatePaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        // Validate the model
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(paymentRequest, serviceProvider: null, items: null);
        bool isValid = Validator.TryValidateObject(paymentRequest, context, validationResults, validateAllProperties: true);
        if (!isValid)
            return Result<CreatePaymentResponse>.Fail(validationResults.FirstOrDefault().ErrorMessage);

        string payload = $@"
                {{
                    ""profile_id"": ""{profileId}"",
                    ""tran_type"": ""{paymentRequest.TransactionType.ToString()}"",
                    ""tran_class"": ""{paymentRequest.TransactionClass.ToString()}"",
                    ""cart_description"": ""{paymentRequest.Description}"",
                    ""cart_id"": ""{paymentRequest.MerchantOrderReferenceKey}"",
                    ""cart_currency"": ""{paymentRequest.PaymentInfo.CurrencyThreeLetterCode}"",
                    ""cart_amount"": {paymentRequest.PaymentInfo.Total},
                    ""callback"": ""{paymentRequest.CallbackUrl}"",
                    ""return"": ""{paymentRequest.ReturnUrl}"",
                    ""customer_details"": {{
                        ""name"": ""{paymentRequest.CustomerInfo.FirstName} {paymentRequest.CustomerInfo.LastName}"",
                        ""email"": ""{paymentRequest.CustomerInfo.Email}"",
                        ""phone"": ""{paymentRequest.CustomerInfo.Phone}""
                    }}
                }}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", serverKey);
            HttpResponseMessage response = await client.PostAsync(paymentRequestEndpoint, new StringContent(payload, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
                return Result<CreatePaymentResponse>.Fail(response.ReasonPhrase);

            string responseBody = await response.Content.ReadAsStringAsync();
            CreatePaymentResponse createPaymentResponse = JsonSerializer.Deserialize<CreatePaymentResponse>(responseBody);
            return Result<CreatePaymentResponse>.Ok(createPaymentResponse);
        }
    }

    public async Task<Result<QueryPaymentResponse>> QueryPayment(string transactionReference, CancellationToken cancellationToken)
    {
        // Validate the model
        if (string.IsNullOrWhiteSpace(transactionReference))
            return Result<QueryPaymentResponse>.Fail("Please provide valid transaction reference");

        string payload = $@"
                {{
                    ""profile_id"": ""{profileId}"",
                    ""tran_ref"": ""{transactionReference}""
                }}";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", serverKey);
            HttpResponseMessage response = await client.PostAsync(queryTokenEndpoint, new StringContent(payload, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
                return Result<QueryPaymentResponse>.Fail(response.ReasonPhrase);

            string responseBody = await response.Content.ReadAsStringAsync();
            QueryPaymentResponse queryPaymentResponse = JsonSerializer.Deserialize<QueryPaymentResponse>(responseBody);

            return Result<QueryPaymentResponse>.Ok(queryPaymentResponse);
        }
    }
}
