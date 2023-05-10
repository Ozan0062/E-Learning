using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Courses
{
	public class EditModel : EditPageModel<Course>
	{
		public EditModel(ICourseDataService dataService)
			: base(dataService)
		{
		}
	}
}
