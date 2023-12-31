﻿
internal static class ConfigureApiBuilderExtension
{
    public static ConfigureHostBuilder AddJsonSettings(this ConfigureHostBuilder api)
    {
        _ = api.ConfigureAppConfiguration((context, config) =>
        {
            const string configurationsDirectory = "Configurations";
            IHostEnvironment? env = context.HostingEnvironment;

            config.AddJsonFile($"{configurationsDirectory}/appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            config.AddJsonFile($"{configurationsDirectory}/eventbus.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/eventbus.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

            .AddEnvironmentVariables();
        });
        return api;
    }
}
