using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

public class LogInPageModel : PageModel
{
    private IUserDataService _userDataService;

    public static User LoggedInUser { get; set; }

    [BindProperty, DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [Display(Name = "Adgangskode")]
    [BindProperty, DataType(DataType.Password)]
    public string Password { get; set; }

    public string Message { get; set; }

    public LogInPageModel(IUserDataService userDataService)
    {
        _userDataService = userDataService;
    }
    public async Task<IActionResult> OnPost()
    {
        LoggedInUser = _userDataService.VerifyUser(Email, Password);

        if (LoggedInUser == null)
        {
            Message = "Invalid attempt";
            return Page();
        }

        // Log in with identity
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            BuildClaimsPrincipal(LoggedInUser));

        return RedirectToPage("/Profile/ProfilePage");
    }


    private ClaimsPrincipal BuildClaimsPrincipal(User user)
    {
        // Build Claims
        List<Claim> claims = new List<Claim> {
          new Claim(ClaimTypes.Email, user.Email) };

        // Create claims-based identity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        // Create and return principal
        return new ClaimsPrincipal(claimsIdentity);

    }

}

