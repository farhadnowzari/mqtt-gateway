namespace MqttGateway.Options;

public class MqttOptions
{
    public const string Mqtt = "Mqtt";
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}