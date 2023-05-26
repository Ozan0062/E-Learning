using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;

public class AdminProfilePageModel : PageModel
{
    private readonly IAdminDataService _adminDataService;

    public AdminProfilePageModel(IAdminDataService adminDataService)
    {
        _adminDataService = adminDataService;
    }

    public Admin LoggedInAdmin { get; set; }

    public void OnGet(int adminId)
    {
        adminId = AdminLogInModel.LoggedInAdmin.Id;
    }
}
