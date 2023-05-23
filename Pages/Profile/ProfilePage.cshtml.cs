using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;

public class ProfilePageModel : PageModel
{
    private readonly IUserDataService _userDataService;
    private readonly IFavoriteDataService _favoriteDataService;

    public ProfilePageModel(IUserDataService userDataService, IFavoriteDataService favoriteDataService) 
    {
        _userDataService = userDataService;
        _favoriteDataService = favoriteDataService;
    }

    public User LoggedInUser { get; set; }
    public List<Course> FavoriteCourses { get; set; }
 
    public void OnGet(int userId)
    {
        userId = LogInPageModel.LoggedInUser.Id;

        FavoriteCourses = _favoriteDataService.Favorite
            .Where(f => f.UserId == userId)
            .Select(f => f.Course)
            .ToList();
    }
}
