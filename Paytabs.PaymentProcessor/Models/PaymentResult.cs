using System.Text.Json.Serialization;

namespace Paytabs.PaymentProcessor.Models;

public class PaymentResult
{
    [JsonPropertyName("response_status")]
    public string ResponseStatus { get; set; }
    [JsonPropertyName("response_message")]
    public string ResponseMessage { get; set; }
}