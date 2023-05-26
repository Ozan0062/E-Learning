using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Pages.Exercises
{
	public class ViewModel : ViewPageModel<Exercise>
	{
		private readonly ELearningDBContext _context;

		public ViewModel(IExerciseDataService dataService, ICourseDataService courseDataService)
			: base(dataService)
		{
			_dataService = dataService;
			CourseList = new SelectList(courseDataService.GetAll(), nameof(Course.Id), nameof(Course.Name));
		}
		public SelectList CourseList { get; set; }

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
