﻿using RabbitMQ.Client;
using RestauranteService.Application.Dtos;
using RestauranteService.Core.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace RestauranteService.Application.Services.RabbitMqClient
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;

            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = int.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
        }

        public void PublicarRestaurante(RestauranteReadDto restauranteReadDto)
        {
            string mensagem = JsonSerializer.Serialize(restauranteReadDto);
            var body = Encoding.UTF8.GetBytes(mensagem);

            _channel.BasicPublish(exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body
                );
        }
    }
}
