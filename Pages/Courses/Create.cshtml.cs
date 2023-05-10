using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Courses
{
	public class CreateModel : CreatePageModel<Course>
	{
		public CreateModel(ICourseDataService dataService)
			: base(dataService)
		{
		}
	}
}
