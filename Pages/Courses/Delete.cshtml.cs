using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Courses
{
	public class DeleteModel : DeletePageModel<Course>
	{
		public DeleteModel(ICourseDataService dataService)
			: base(dataService)
		{
		}
	}
}
