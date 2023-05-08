using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
public class LogOutPageModel : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        LogInPageModel.LoggedInUser = null;
        AdminLogInModel.LoggedInAdmin = null;
        InstructorLogInModel.LoggedInInstructor = null;

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToPage("/Index");
    }
}

