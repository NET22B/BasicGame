using BasicGame.ConsoleGame.Entities.Items;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Startup
{
    private IConfiguration configuration;

    public Startup()
    {
        configuration = GetConfig();
    }

    internal void SetUp()
    {
        var serviceCollcetion = new ServiceCollection();
        ConfigureServices(serviceCollcetion);

        IServiceProvider serviceProvider = serviceCollcetion.BuildServiceProvider();
        serviceProvider.GetRequiredService<Game>().Run();
       
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton(configuration);
        services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton<IMap, Map>();
        services.AddSingleton<Game>();
        services.AddSingleton(configuration.GetSection("game:mapsettings").Get<MapSettings>());
        services.Configure<MapSettings>(configuration.GetSection("game:mapsettings").Bind);
        services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
        services.AddSingleton<ILimitedList<Item>>(new LimitedList<Item>(3));
    }

    private IConfiguration GetConfig()
    {
        return new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
    }
}