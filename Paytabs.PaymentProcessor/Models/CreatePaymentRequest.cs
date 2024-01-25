using System.ComponentModel.DataAnnotations;
using Paytabs.PaymentProcessor.Infrastructure;

namespace Paytabs.PaymentProcessor.Models;

public class CreatePaymentRequest
{
    public string CallbackUrl { get; set; }
    [Required]
    public string ReturnUrl { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string MerchantOrderReferenceKey { get; set; }
    [Required]
    public CustomerInfo CustomerInfo { get; set; }
    [Required]
    public PaymentInfo PaymentInfo { get; set; }
    [Required]
    public TransactionType TransactionType { get; set; }
    [Required]
    public TransactionClass TransactionClass { get; set; }
}