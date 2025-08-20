using Utils;

namespace Pages;

public class AssetsListPage : BasePage
{
    private readonly string _baseUrl;
    public AssetsListPage(IPage page, string baseUrl) : base(page) { _baseUrl = baseUrl; }

    public async Task GotoAsync() => await Page.GotoAsync($"{_baseUrl}/hardware");

    public async Task OpenCreateAssetAsync()
    {
        await ClickAsync(S.CreateNewDropdown);
        await ClickAsync(S.CreateNewAssetLink);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task SearchAsync(string term)
    {
        var search = Page.Locator(S.AssetsListSearchInput).First;
        if (await search.IsVisibleAsync())
        {
            await search.FillAsync(term);
            await Page.Keyboard.PressAsync("Enter");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }

    public async Task OpenAssetFromListAsync(string assetName)
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = assetName }).First.ClickAsync();
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    public async Task<bool> IsAssetListedAsync(string assetName)
        => await Page.GetByText(assetName, new() { Exact = false }).IsVisibleAsync();
}
