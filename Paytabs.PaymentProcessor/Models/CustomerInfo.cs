using System.ComponentModel.DataAnnotations;

namespace Paytabs.PaymentProcessor.Models;

public class CustomerInfo
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}