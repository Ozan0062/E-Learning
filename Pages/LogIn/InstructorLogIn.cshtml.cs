using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

public class InstructorLogInModel : PageModel
{
    private IInstructorDataService _instructorDataService;

    public static Instructor LoggedInInstructor { get; set; }

    [BindProperty, DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [Display(Name = "Adgangskode")]
    [BindProperty, DataType(DataType.Password)]
    public string Password { get; set; }

    public string Message { get; set; }

    public InstructorLogInModel(IInstructorDataService instructorDataService)
    {
        _instructorDataService = instructorDataService;
    }
    public async Task<IActionResult> OnPost()
    {
        LoggedInInstructor = _instructorDataService.VerifyInstructor(Email, Password);

        if (LoggedInInstructor == null)
        {
            Message = "Invalid attempt";
            return Page();
        }

        // Log in with identity
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            BuildClaimsPrincipal(LoggedInInstructor));

        return RedirectToPage("/Profile/InstructorProfilePage");
    }


    private ClaimsPrincipal BuildClaimsPrincipal(Instructor instructor)
    {
        // Build Claims
        List<Claim> claims = new List<Claim> {
          new Claim(ClaimTypes.Email, instructor.Email) };

        // Create claims-based identity
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        // Create and return principal
        return new ClaimsPrincipal(claimsIdentity);

    }

}



