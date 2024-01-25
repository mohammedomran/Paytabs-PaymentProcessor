using System.ComponentModel.DataAnnotations;

namespace Paytabs.PaymentProcessor.Models;

public class PaymentInfo
{
    [Required]
    public double Total { get; set; }
    [Required]
    public object CurrencyThreeLetterCode { get; set; }
}