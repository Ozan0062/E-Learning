using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Courses
{
	public class ViewModel : ViewPageModel<Course>
	{
		public ViewModel(ICourseDataService dataService)
			: base(dataService)
		{
		}
	}
}
