using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

public class AdminLogInModel : PageModel
{
    private IAdminDataService _adminDataService;

    public static Admin LoggedInAdmin { get; set; }

    [BindProperty, DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [Display(Name = "Adgangskode")]
    [BindProperty, DataType(DataType.Password)]
    public string Password { get; set; }

    public string Message { get; set; }

    public AdminLogInModel(IAdminDataService adminDataService)
    {
        _adminDataService = adminDataService;
    }
    public async Task<IActionResult> OnPost()
    {
        LoggedInAdmin = _adminDataService.VerifyAdmin(Email, Password);

        if (LoggedInAdmin == null)
        {
            Message = "Invalid attempt";
            return Page();
        }

        // Log in with identity
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            BuildClaimsPrincipal(LoggedInAdmin));

        return RedirectToPage("/Profile/AdminProfilePage");
    }


    private ClaimsPrincipal BuildClaimsPrincipal(Admin admin)
    {
        // Build Claims
        List<Claim> claims = new List<Claim> {
          new Claim(ClaimTypes.Email, admin.Email) };

        // Create claims-based identity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        // Create and return principal
        return new ClaimsPrincipal(claimsIdentity);

    }

}


