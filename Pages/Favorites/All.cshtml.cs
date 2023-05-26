using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Pages.Favorites
{
    public class AllModel : PageModel
    {
        private readonly IFavoriteDataService _favoriteDataService;
        private readonly ICourseDataService _courseDataService;
        private readonly IExerciseStatusDataService _exerciseStatusDataService;
        private readonly IExerciseDataService _exerciseDataService;
        private readonly ELearningDBContext _context;

        public List<Course> FavoriteCourses { get; set; } = new List<Course>();
        public int Status { get; set; } 
        public AllModel(IFavoriteDataService favoriteDataService,
                        ICourseDataService courseDataService,
                        IExerciseDataService exerciseDataService,
                        IExerciseStatusDataService exerciseStatusDataService,
                        ELearningDBContext context)
        {
            _favoriteDataService = favoriteDataService;
            _courseDataService = courseDataService;
            _exerciseDataService = exerciseDataService;
            _exerciseStatusDataService = exerciseStatusDataService;
            _context = context;

            this._exerciseStatusDataService = exerciseStatusDataService;
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

        public async Task<IActionResult> OnGetDownloadFileAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null || exercise.Data == null)
            {
                return NotFound();
            }

            return File(exercise.Data, exercise.ContentType, exercise.FileName);
        }

        public async Task<IActionResult> OnPostAddToDoneAsync(int exerciseId)
        {
            if (LogInPageModel.LoggedInUser != null)
            {
                var exerciseStatus = new ExerciseStatus
                {
                    UserId = LogInPageModel.LoggedInUser.Id,
                    ExerciseId = exerciseId,
                    Status = 1
                };

                this._exerciseStatusDataService.Create(exerciseStatus);

                return RedirectToPage("/ExerciseStatuses/All");
            }

            return Unauthorized();
        }
    }
}