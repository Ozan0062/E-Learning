using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Educations
{
	public class DeleteModel : DeletePageModel<Education>
	{
		public DeleteModel(IEducationDataService dataService)
			: base(dataService)
		{
		}
	}
}
