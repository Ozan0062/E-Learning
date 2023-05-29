using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class FavoritesPageModel : PageModel
{
    private readonly IFavoriteDataService _favoriteDataService;
    private readonly ICourseDataService _courseDataService;
    private readonly IExerciseStatusDataService _exerciseStatusDataService;
    protected readonly ELearningDBContext _context;

    public List<Course> FavoriteCourses { get; set; } = new List<Course>();
    public List<ExerciseStatus> ExerciseStatusesDone { get; set; }

    protected FavoritesPageModel(IFavoriteDataService favoriteDataService,
                                 ICourseDataService courseDataService,
                                 IExerciseStatusDataService exerciseStatusDataService,
                                 ELearningDBContext context)
    {
        _favoriteDataService = favoriteDataService;
        _courseDataService = courseDataService;
        _exerciseStatusDataService = exerciseStatusDataService;
        _context = context;
    }

    protected void LoadFavoriteCourses()
    {
        var favorites = _favoriteDataService.GetFavoritesForUser(LogInPageModel.LoggedInUser.Id);
        FavoriteCourses = favorites
            .Where(favorite => favorite.CourseId.HasValue)
            .Select(favorite => _courseDataService.GetCourseWithExercises(favorite.CourseId.Value))
            .Where(course => course != null && !FavoriteCourses.Any(c => c.Id == course.Id))
            .ToList();
    }

    protected async Task LoadExerciseStatusesDone()
    {
        ExerciseStatusesDone = await _context.ExerciseStatuses
            .Where(es => es.UserId == LogInPageModel.LoggedInUser.Id && es.Status == 1)
            .Include(es => es.Exercise)
            .GroupBy(es => new { es.UserId, es.ExerciseId })
            .Select(g => g.First())
            .ToListAsync();
    }

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
