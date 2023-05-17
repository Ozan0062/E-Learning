using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProfilePageModel : PageModel
{
    private readonly IUserDataService _userDataService;

    public ProfilePageModel(IUserDataService userDataService)
    {
        _userDataService = userDataService;
    }

    public User LoggedInUser { get; set; }

    //public void OnGet()
    //{
    //    LoggedInUser = GetLoggedInUser();
    //}

    //private User GetLoggedInUser()
    //{
    //    // Logic to retrieve the logged-in user from the data service
    //    // You can use the HttpContext.User.Identity.Name or any other identifier to fetch the user data
    //    // Replace the following code with your own logic
    //    string loggedInUserName = User.Identity.Name;
    //    LoggedInUser = _userDataService.VerifyUser(providedEmail, Password);
    //    return loggedInUser;
    //}
}