namespace Paytabs.PaymentProcessor.Models;

public class PaytabsConfiguration
{
    public static string LiveServerKey { get; set; }
    public static long LiveProfileId { get; set; }
    public static string TestServerKey { get; set; }
    public static long TestProfileId { get; set; }
    public static bool HideShipping { get; set; }
    public static bool EnableIframe { get; set; }
    public static bool TestMode { get; set; }
}
