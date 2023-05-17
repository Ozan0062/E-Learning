using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Learning.Pages.Exercises
{
    public class CreateModel : CreatePageModel<Exercise>
    {
        public CreateModel(IExerciseDataService dataService, ICourseDataService courseDataService)
            : base(dataService)
        {
			CourseList = new SelectList(courseDataService.GetAll(), nameof(Course.Id), nameof(Course.Name));
	    }

	public SelectList CourseList { get; set; }
}
}
