using Utils;

namespace Pages;

public class LoginPage : BasePage
{
    private readonly string _baseUrl;
    public LoginPage(IPage page, string baseUrl) : base(page) { _baseUrl = baseUrl; }

    public async Task GotoAsync() => await Page.GotoAsync($"{_baseUrl}/login");

    public async Task LoginAsync(string username, string password)
    {
        await FillAsync(S.Username, username);
        await FillAsync(S.Password, password);
        await ClickAsync(S.LoginButton);
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await DismissCommonPopupIfAny();
    }
}
