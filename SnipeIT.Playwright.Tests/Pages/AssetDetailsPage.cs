using Utils;

namespace Pages;

public class AssetDetailsPage : BasePage
{
    public AssetDetailsPage(IPage page) : base(page) { }

    public async Task<bool> HasStatusAsync(string statusText)
        => await Page.GetByText(statusText, new() { Exact = false }).IsVisibleAsync();

    public async Task OpenHistoryAsync()
    {
        await ClickAsync(S.HistoryTab);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> HasHistoryTextAsync(string contains)
        => (await Page.InnerTextAsync("body")).Contains(contains, StringComparison.OrdinalIgnoreCase);
}
