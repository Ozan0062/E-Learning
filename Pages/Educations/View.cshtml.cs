using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Educations
{
	public class ViewModel : ViewPageModel<Education>
	{
		public ViewModel(IEducationDataService dataService)
			: base(dataService)
		{
		}
	}
}
