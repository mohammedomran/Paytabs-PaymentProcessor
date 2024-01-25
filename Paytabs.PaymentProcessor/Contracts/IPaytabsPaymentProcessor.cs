using Paytabs.PaymentProcessor.Infrastructure;
using Paytabs.PaymentProcessor.Models;

namespace Paytabs.PaymentProcessor.Contracts;

public interface IPaytabsPaymentProcessor
{
    Task<Result<CreatePaymentResponse>> CreatePaymentRequest(CreatePaymentRequest paymentRequest, CancellationToken cancellationToken);
    Task<Result<QueryPaymentResponse>> QueryPayment(string transactionReference, CancellationToken cancellationToken);
}
