using System.Text.Json.Serialization;

namespace Paytabs.PaymentProcessor.Models;
public class QueryPaymentResponse
{
    [JsonPropertyName("tran_currency")]
    public string CurrencyThreeLetterCode { get; set; }
    [JsonPropertyName("tran_total")]
    public string Total { get; set; }
    [JsonPropertyName("tran_ref")]
    public string TransactionReference { get; set; }
    [JsonPropertyName("cart_id")]
    public string MerchantOrderReferenceKey { get; set; }
    [JsonPropertyName("payment_result")]
    public PaymentResult PaymentResult { get; set; }

}
