using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace E_Learning.Pages.ExerciseStatuses
{
    public class AllModel : FavoritesPageModel
    {
        private readonly IExerciseStatusDataService _exerciseStatusDataService;
        private readonly IExerciseDataService _exerciseDataService;

        public AllModel(IFavoriteDataService favoriteDataService,
                        ICourseDataService courseDataService,
                        IExerciseDataService exerciseDataService,
                        IExerciseStatusDataService exerciseStatusDataService,
                        ELearningDBContext context)
            : base(favoriteDataService, courseDataService, exerciseStatusDataService, context)
        {
            _exerciseDataService = exerciseDataService;
            _exerciseStatusDataService = exerciseStatusDataService;
        }

        public async Task OnGetAsync()
        {
            LoadFavoriteCourses();
            await LoadExerciseStatusesDone();

        }

        public async Task<IActionResult> OnPostDeleteExerciseStatusAsync(int id)
        {
            var exerciseStatus = await _context.ExerciseStatuses.FindAsync(id);
            _context.ExerciseStatuses.Remove(exerciseStatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ExerciseStatuses/All");
        }

        public int GetExercisesDoneCountForCourse(int courseId, int userId)
        {
            return _context.ExerciseStatuses
                           .Where(s => s.Exercise.CourseId == courseId && s.Status == 1 && s.UserId == userId)
                           .Select(s => s.ExerciseId)
                           .Distinct()
                           .Count();
        }
    }
}
