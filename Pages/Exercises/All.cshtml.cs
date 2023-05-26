using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Pages.Exercises
{
    public class AllModel : GetAllPageModel<Exercise>
    {
        private readonly ELearningDBContext _context;
        

        public AllModel(IExerciseDataService dataService, ELearningDBContext context, IEducationDataService educationDataService)
            : base(dataService)
        {
            _context = context;
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
