using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Educations
{
	public class EditModel : EditPageModel<Education>
	{
		public EditModel(IEducationDataService dataService)
			: base(dataService)
		{
		}
	}
}
