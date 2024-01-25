using System.Text.Json.Serialization;

namespace Paytabs.PaymentProcessor.Models;

public class CreatePaymentResponse
{
    [JsonPropertyName("redirect_url")]
    public string RedirectUrl { get; set; }
    [JsonPropertyName("tran_ref")]
    public string TransactionReference { get; set; }
    [JsonPropertyName("cart_id")]
    public string MerchantOrderReferenceKey { get; set; }
}