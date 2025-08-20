\
namespace Utils;

public static class S
{
    // Login
    public const string Username = "#username, input[name='username']";
    public const string Password = "#password, input[name='password']";
    public const string LoginButton = "#submit, button[type='submit']:has-text('Login'), button:has-text('Login')";

    // Header / Dashboard
    public const string CreateNewDropdown = "text=Create New";
    public const string CreateNewAssetLink = "a[href*='/hardware/create'], text=Asset";

    // Create Asset Page
    public const string CompanySelect2Container = "#select2-company_select-container";
    public const string ModelSelect2Container = "#select2-model_select_id-container";
    public const string StatusSelect2Container = "#select2-status_select_id-container";
    public const string LocationSelect2Container = "#select2-rtd_location_id_location_select-container";
    public const string Select2SearchField = "input.select2-search__field";

    public const string AssetTag = "#asset_tag, input[name='asset_tag']";
    public const string Serial = "input[name='serials[]'], #serials\\[\\]";
    public const string Requestable = "input[name='requestable']";
    public const string SaveButton = "#submit_button, button:has-text('Save')";

    // Assets List
    public const string AssetsListSearchInput = "input[type='search'], input[placeholder*='Search']";

    // Details & History
    public const string HistoryTab = "a[href*='history'], text=History";
}
