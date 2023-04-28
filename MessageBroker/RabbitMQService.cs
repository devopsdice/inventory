namespace Order.MessageBroker
{
    using Order.Model;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class RabbitMQService: IMessageBrokerService
    {
        private ConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel model;
        public RabbitMQService()
        {
            connectionFactory = new ConnectionFactory
            {
                Uri =
                new Uri("amqp://guest:guest@localhost:5672/")
            };
            connection = connectionFactory.CreateConnection();
            model = connection.CreateModel();
            model.QueueDeclare("Inventorary_Queue",exclusive:false,durable:true,autoDelete:false);
            var consumer= new EventingBasicConsumer(model);
            consumer.Received += Consumer_Received;
             
           
        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            
        }

        public void PublishMessage(OrderData orderData)
        {
            
        }

    }
}
