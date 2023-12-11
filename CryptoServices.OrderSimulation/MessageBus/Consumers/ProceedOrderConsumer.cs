using CryptoServices.OrderSimulation.MessageBus.Messages;
using MassTransit;

namespace CryptoServices.OrderSimulation.MessageBus.Consumers
{
    public class ProceedOrderConsumer : IConsumer<OrderProceedMessage>
    {
        protected readonly IPublishEndpoint _publisher;

        public ProceedOrderConsumer(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public async Task Consume(ConsumeContext<OrderProceedMessage> context)
        {
            /*await _publisher.Publish(new ProceedOrderPublishMessage() { OrderId = context.Message.OrderId, OrderState = "Proceed" });
            //Emulate things
            await Task.Delay(10000);

            await _publisher.Publish(new ProceedOrderPublishMessage() { OrderId = context.Message.OrderId, OrderState = "Fullfilled" });*/
            await Console.Out.WriteLineAsync("Receive");
        }
    }
}
