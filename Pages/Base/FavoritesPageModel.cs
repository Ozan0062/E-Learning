using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public abstract class FavoritesPageModel : PageModel
{
    private readonly IFavoriteDataService _favoriteDataService;
    private readonly ICourseDataService _courseDataService;
    protected readonly ELearningDBContext _context;

    public List<Course> FavoriteCourses { get; set; } = new List<Course>();

    protected FavoritesPageModel(IFavoriteDataService favoriteDataService, ICourseDataService courseDataService, ELearningDBContext context)
    {
        _favoriteDataService = favoriteDataService;
        _courseDataService = courseDataService;
        _context = context;
    }

    protected void LoadFavoriteCourses()
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
    //Download
    public async Task<IActionResult> OnGetDownloadFileAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        if (exercise == null || exercise.Data == null)
        {
            return NotFound();
        }

        return File(exercise.Data, exercise.ContentType, exercise.FileName);
    }
}
