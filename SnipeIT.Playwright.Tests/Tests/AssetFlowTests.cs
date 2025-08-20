using Pages;
using Utils;

namespace Tests;

public class AssetFlowTests : IClassFixture<PlaywrightFixture>
{
    private readonly PlaywrightFixture _fx;
    public AssetFlowTests(PlaywrightFixture fx) => _fx = fx;

    [Fact(DisplayName = "Snipe-IT: Create asset, verify in list, validate details & history")]
    public async Task CreateAndValidateAssetFlow()
    {
        var settings = _fx.Settings;

        var context = await _fx.Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new() { Width = 1400, Height = 900 },
            IgnoreHTTPSErrors = true
        });
        var page = await context.NewPageAsync();

        // 1) Login
        var login = new LoginPage(page, settings.BaseUrl);
        await login.GotoAsync();
        await login.LoginAsync(settings.Username, settings.Password);

        // 2) Go to Create Asset
        var list = new AssetsListPage(page, settings.BaseUrl);
        await list.GotoAsync();
        await list.OpenCreateAssetAsync();

        // 3) Fill form & Save
        var create = new CreateAssetPage(page);
        var ts = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var assetTag = $"MacBook-Pro-13-{ts}";
        await create.CreateAssetAsync(assetTag, serial: $"SN-{ts}", company: "Acme", model: "Mac", status: "Ready to Deploy", location: "HQ");

        // 4) Verify appears in list
        await list.GotoAsync();
        await list.SearchAsync(assetTag);
        (await list.IsAssetListedAsync(assetTag)).Should().BeTrue("newly created asset should be listed");

        // 5) Open details
        await list.OpenAssetFromListAsync(assetTag);
        var details = new AssetDetailsPage(page);
        (await details.HasStatusAsync("Ready to Deploy")).Should().BeTrue("status should be Ready to Deploy");

        // 6) Check History
        await details.OpenHistoryAsync();
        (await details.HasHistoryTextAsync("created")).Should().BeTrue("history should show creation event");

        await context.CloseAsync();
    }
}
