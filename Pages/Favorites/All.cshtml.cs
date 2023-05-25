using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Favorites
{
    public class AllModel : PageModel
    {
        private readonly IFavoriteDataService _favoriteDataService;
        private readonly ICourseDataService _courseDataService;

        public List<Course> FavoriteCourses { get; set; } = new List<Course>();

        public AllModel(IFavoriteDataService favoriteDataService, ICourseDataService courseDataService)
        {
            _favoriteDataService = favoriteDataService;
            _courseDataService = courseDataService;
        }

        public void OnGet()
        {
            var favorites = _favoriteDataService.GetFavoritesForUser(LogInPageModel.LoggedInUser.Id);
            foreach (var favorite in favorites)
            {
                if (favorite.CourseId.HasValue)
                {
                    var course = _courseDataService.GetCourseWithExercises(favorite.CourseId.Value);
                    if (course != null && !FavoriteCourses.Any(c => c.Id == course.Id))
                    {
                        FavoriteCourses.Add(course);
                    }
                }
            }
        }


    }
}
