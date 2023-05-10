using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Courses
{
	public class AllModel : GetAllPageModel<Course>
	{
		public AllModel(ICourseDataService dataService)
			: base(dataService)
		{
		}
	}
}
