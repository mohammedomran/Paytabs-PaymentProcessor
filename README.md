## Getting Started

1.  **Configure Paytabs Services:**

	**Getting Started Configure Paytabs Services:**

	The first step is to configure Paytabs services in your application. Add the required services in the Startup.cs or program file (based on  your ASP.NET Core version):
```csharp
services.AddPaytabsServices(configuration); 
```

2. **Configure App Settings:**

	Add the Paytabs configuration section to your appsettings.json or any other configuration source:
```json
"PaytabsConfiguration": { 
	"TestServerKey": "YourTestServerKey", 
	"TestProfileId": "YourTestProfileId", 
	"LiveServerKey": "YourLiveServerKey", 
	"LiveProfileId": "YourLiveProfileId", 
	"HideShipping": "true", 
	"EnableIFrame": "true", 
	"TestMode": "false" 
} 
```
3. **And you're done:**
	Now you can use the package to create your payment request, for this you can use the IPaytabsPaymentProcessor interface to perform payment operations. Here's an example usage:


```csharp
public PaymentController(IPaytabsPaymentProcessor paymentProcessor)
{
    _paymentProcessor = paymentProcessor;
}

public async Task<IActionResult> OnGet()
{
    var createPaymentRequest = new CreatePaymentRequest
    {
        ReturnUrl = "https://localhost:5000/",
        Description = "test description",
        MerchantOrderReferenceKey = new Random().Next(100000, 999999).ToString(),
        CustomerInfo = new CustomerInfo
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email",
            Phone = "Phone"
        },
        PaymentInfo = new PaymentInfo
        {
            CurrencyThreeLetterCode = "SAR",
            Total = 50
        },
        TransactionType = TransactionType.ecom,
        TransactionClass = TransactionClass.sale,
    };

    var createPaymentResponse = await _paymentProcessor.CreatePaymentRequest(createPaymentRequest, new CancellationToken());

    if (result.IsSuccess)
        return Redirect(result.Value.RedirectUrl);
        
	// Handle failure scenario
	return Page();
}
```

4. **Get payment result:**
	 you can send the transaction reference key to the QueryPayment method in the inerface to get your payment status

    
```csharp
    var queryPaymentResult = await _paymentProcessor.QueryPayment("YourTransactionReferenceKey", new CancellationToken());
    return Page();
}
```

Feel free to customize the provided code snippets based on your application's requirements.


## Models

### `CreatePaymentRequest` Class

This class represents the request for creating a payment. It includes properties such as `CallbackUrl`, `ReturnUrl`, `Description`, and more.

### `CreatePaymentResponse` Class

This class represents the response after creating a payment. It includes properties like `RedirectUrl`, `TransactionReference`, and `MerchantOrderReferenceKey`.

### `CustomerInfo` Class

This class represents information about the customer, including properties like `FirstName`, `LastName`, `Email`, and `Phone`.

### `PaymentInfo` Class

This class represents information about the payment, including properties like `Total` and `CurrencyThreeLetterCode`.

### `QueryPaymentResponse` Class

This class represents the response after querying a payment. It includes properties like `CurrencyThreeLetterCode`, `Total`, `TransactionReference`, `MerchantOrderReferenceKey`, and `PaymentResult`.

## Configuration

### `PaytabsConfiguration` Class

This class represents the configuration options for the Paytabs services. It includes static properties for both live and test environments, such as server keys, profile IDs, and other settings.
## Methods

### `IPaytabsPaymentProcessor` Interface

This interface defines methods for payment processing:

-   `CreatePaymentRequest`: Creates a payment request.
-   `QueryPayment`: Queries the status of a payment.
