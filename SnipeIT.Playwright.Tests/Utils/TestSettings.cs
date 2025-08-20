using Microsoft.Extensions.Configuration;

namespace Utils;

public sealed class TestSettings
{
    public string BaseUrl { get; init; } = "";
    public string Username { get; init; } = "";
    public string Password { get; init; } = "";
    public bool Headless { get; init; } = true;
    public int DefaultTimeoutMs { get; init; } = 30000;

    public static TestSettings Load()
    {
        var cfg = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();
        return cfg.Get<TestSettings>()!;
    }
}
