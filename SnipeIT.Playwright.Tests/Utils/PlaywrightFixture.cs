using Utils;

namespace Utils;

public class PlaywrightFixture : IAsyncLifetime
{
    public IPlaywright PW { get; private set; } = default!;
    public IBrowser Browser { get; private set; } = default!;
    public TestSettings Settings { get; } = TestSettings.Load();

    public async Task InitializeAsync()
    {
        PW = await Playwright.CreateAsync();
        Browser = await PW.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = Settings.Headless,
            Args = new[]
            {
                "--disable-features=AutofillServerCommunication,PasswordManagerOnboarding,PasswordManagerEnableAccountStorage",
                "--disable-notifications"
            }
        });
    }

    public async Task DisposeAsync()
    {
        await Browser.DisposeAsync();
        PW.Dispose();
    }
}
