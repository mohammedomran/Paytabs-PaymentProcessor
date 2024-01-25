namespace Paytabs.PaymentProcessor.Infrastructure;

public static class Endpoints
{
    private static string BaseEndpoint = "https://secure.paytabs.sa/payment/";
    public static string PaymentRequestEndpoint = $"{BaseEndpoint}request";
    public static string QueryTokenEndpoint = $"{BaseEndpoint}query";
    public static string DeleteTokenEndpoint = $"{BaseEndpoint}token/delete";
}

