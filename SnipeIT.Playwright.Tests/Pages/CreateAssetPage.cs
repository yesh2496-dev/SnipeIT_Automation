using Utils;

namespace Pages;

public class CreateAssetPage : BasePage
{
    public CreateAssetPage(IPage page) : base(page) { }

    public async Task CreateAssetAsync(string assetTag, string serial, string company = "Acme", string model = "MacBook", string status = "Ready to Deploy", string location = "HQ")
    {
        // Company (select2)
        await Select2Async(S.CompanySelect2Container, company);

        // Asset Tag
        await FillAsync(S.AssetTag, assetTag);

        // Serial
        var serialInput = Page.Locator(S.Serial).First;
        if (await serialInput.IsVisibleAsync())
            await serialInput.FillAsync(serial);

        // Model (select2)
        await Select2Async(S.ModelSelect2Container, model);

        // Status (select2)
        await Select2Async(S.StatusSelect2Container, status);

        // Location (select2)
        await Select2Async(S.LocationSelect2Container, location);

        // Requestable checkbox
        var req = Page.Locator(S.Requestable).First;
        if (await req.IsVisibleAsync() && !(await req.IsCheckedAsync()))
            await req.CheckAsync();

        // Save
        await ClickAsync(S.SaveButton);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}
