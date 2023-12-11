namespace CryptoServices.OrderSimulation.MessageBus.Messages
{
    public class ProceedOrderPublishMessage
    {
        public Guid OrderId { get; set; }
        public string OrderState { get; set; }
    }
}
