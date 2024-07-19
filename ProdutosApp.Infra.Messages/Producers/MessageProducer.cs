using Newtonsoft.Json;
using ProdutosApp.Domain.Dtos;
using ProdutosApp.Domain.Interfaces.Messages;
using ProdutosApp.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Messages.Producers
{
    /// <summary>
    /// Classe para conexão com a fila e gravação das mensagens
    /// </summary>
    public class MessageProducer : IMessageProducer
    {
        private readonly IConnectionFactory? _connectionFactory;
        private readonly RabbitMQSettings? _settings;

        public MessageProducer(IConnectionFactory? connectionFactory, RabbitMQSettings? settings)
        {
            _connectionFactory = connectionFactory;
            _settings = settings;
        }

        public void CreateLogProdutos(ProdutosLogDto dto)
        {
            using var connection = _connectionFactory?.CreateConnection();
            using var channel = connection?.CreateModel();

            //Criando a fila
            channel?.QueueDeclare(queue: _settings?.Queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            //serializando os dados para gravação
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            //gravando na fila
            channel.BasicPublish(exchange: string.Empty, routingKey: _settings?.Queue, basicProperties: null, body: body);
        }

        public void CreateLogFornecedores(FornecedoresLogDto dto)
        {
            using var connection = _connectionFactory?.CreateConnection();
            using var channel = connection?.CreateModel();

            //Criando a fila
            channel?.QueueDeclare(queue: _settings?.Queue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            //serializando os dados para gravação
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));

            //gravando na fila
            channel.BasicPublish(exchange: string.Empty, routingKey: _settings?.Queue, basicProperties: null, body: body);
        }
        
    }
}
