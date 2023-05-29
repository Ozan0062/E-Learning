using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Pages.Courses
{
    public class AllModel : GetAllPageModel<Course>
    {
        private readonly IFavoriteDataService favoriteDataService;

        public AllModel(ICourseDataService dataService,
                        IFavoriteDataService favoriteDataService)
            : base(dataService)
        {
            this.favoriteDataService = favoriteDataService;
        }

        public IActionResult OnPostAddToFavorites(int courseId)
        {
            if (LogInPageModel.LoggedInUser != null)
            {
                var favorite = new Favorite
                {
                    UserId = LogInPageModel.LoggedInUser.Id,
                    CourseId = courseId
                };

                this.favoriteDataService.Create(favorite);

                return RedirectToPage("/Favorites/All");
            }

            return Unauthorized();
        }
    }
}
