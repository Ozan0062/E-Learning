using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

// F
namespace E_Learning.Pages.Exercises
{
	public class CreateModel : CreatePageModel<Exercise>
	{
		private readonly IExerciseDataService _dataService;

		public CreateModel(IExerciseDataService dataService, ICourseDataService courseDataService)
			: base(dataService)
		{
			_dataService = dataService;
			CourseList = new SelectList(courseDataService.GetAll(), nameof(Course.Id), nameof(Course.Name));
		}

		[BindProperty]
		public IFormFile UploadedFile { get; set; }
		public SelectList CourseList { get; set; }
		
		[BindProperty]
		public Exercise Data { get; set; }


		public override IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (UploadedFile != null)
			{
				using (var memoryStream = new MemoryStream())
				{
					UploadedFile.CopyTo(memoryStream);
					Data.Data = memoryStream.ToArray();
					Data.FileName = UploadedFile.FileName;
					Data.ContentType = UploadedFile.ContentType;
				}
			}

			// Here, call your method to create the exercise.
			_dataService.Create(Data);

			return RedirectToPage("/Exercises/All");
		}
	}
}
