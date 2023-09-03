using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using MqttGateway.Services;
using MQTTnet;

namespace MqttGateway.Controllers;

[ApiController]
[Route("mqtt")]
public class MqttController : ControllerBase
{
    private readonly MqttService _mqttService;

    public MqttController(MqttService mqttService)
    {
        _mqttService = mqttService;
    }

    [HttpPost("{topic}")]
    public async Task SendMessage([FromRoute] string topic, object message)
    {
        topic = HttpUtility.UrlDecode(topic);
        var mqttMessage = new MqttApplicationMessageBuilder().WithTopic(topic).WithPayload(JsonSerializer.Serialize(message)).Build();
        await _mqttService.Client.PublishAsync(mqttMessage);
    }
}