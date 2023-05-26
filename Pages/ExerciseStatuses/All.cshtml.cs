using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Pages.ExerciseStatuses
{
    public class AllModel : FavoritesPageModel
    {
        private readonly IExerciseStatusDataService _exerciseStatusDataService;
        private readonly IExerciseDataService _exerciseDataService;
        private readonly ELearningDBContext _context;
        public List<Course> FavoriteCourses { get; set; } = new List<Course>();
        public List<ExerciseStatus> ExerciseStatuses { get; set; }


        public AllModel(IFavoriteDataService favoriteDataService,
                        ICourseDataService courseDataService,
                        IExerciseDataService exerciseDataService,
                        IExerciseStatusDataService exerciseStatusDataService,
                        ELearningDBContext context)
            : base(favoriteDataService, courseDataService)
        {
            _exerciseDataService = exerciseDataService;
            _exerciseStatusDataService = exerciseStatusDataService;
            _context = context;

            this._exerciseStatusDataService = exerciseStatusDataService;
        }
        public List<Exercise> ExercisesDone { get; set; } = new List<Exercise>();

        public void OnGet()
        {
            var exerciseDones = _exerciseStatusDataService.GetExerciseStatusForUser(LogInPageModel.LoggedInUser.Id);
            foreach (var exerciseDone in exerciseDones)
            {
                if (exerciseDone.ExerciseId.HasValue)
                {
                    var exercise = _exerciseDataService.GetExerciseWithExerciseDone(exerciseDone.ExerciseId.Value);
                    if (exercise != null && !ExercisesDone.Any(c => c.Id == exercise.Id))
                    {
                        ExercisesDone.Add(exercise);
                    }
                }
            }
            LoadFavoriteCourses();
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
}
