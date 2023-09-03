using Microsoft.Extensions.Options;
using MqttGateway.Options;
using MQTTnet;
using MQTTnet.Client;

namespace MqttGateway.Services;

public class MqttService
{
    public IMqttClient Client { get; private set; }
    public MqttService(IOptions<MqttOptions> options)
    {
        var mqttFactory = new MqttFactory();
        var mqttClient = mqttFactory.CreateMqttClient();
        var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(options.Value.Host).WithCredentials(options.Value.Username, options.Value.Password).Build();
        mqttClient.ConnectAsync(mqttClientOptions).Wait();
        Client = mqttClient;
    }
}