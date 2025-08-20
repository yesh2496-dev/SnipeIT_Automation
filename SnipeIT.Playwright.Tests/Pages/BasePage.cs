namespace Pages;

public abstract class BasePage
{
    protected readonly IPage Page;
    protected BasePage(IPage page) { Page = page; }

    protected async Task ClickAsync(string selector)
        => await Page.Locator(selector).First.ClickAsync(new LocatorClickOptions { Timeout = 30000 });

    protected async Task FillAsync(string selector, string value)
        => await Page.Locator(selector).First.FillAsync(value, new LocatorFillOptions { Timeout = 30000 });

    protected async Task Select2Async(string containerSelector, string valueToType)
    {
        var container = Page.Locator(containerSelector).First;
        await container.ClickAsync(new LocatorClickOptions { Timeout = 30000, Force = true });
        var search = Page.Locator("input.select2-search__field").First;
        await search.FillAsync(valueToType);
        await Page.Keyboard.PressAsync("Enter");
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    protected async Task DismissCommonPopupIfAny()
    {
        try
        {
            // Try Escape for browser popups like password manager
            await Page.Keyboard.PressAsync("Escape");
            // App-level confirmation with OK
            var ok = Page.Locator("button:has-text('OK'), .modal-dialog button:has-text('OK')").First;
            if (await ok.IsVisibleAsync(new() { Timeout = 1500 })) await ok.ClickAsync();
        }
        catch { /* ignore */ }
    }
}
