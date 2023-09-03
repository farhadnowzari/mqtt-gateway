namespace MqttGateway.Options;

public static class DI
{
    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MqttOptions>(configuration.GetSection(MqttOptions.Mqtt));
        return services;
    }
}