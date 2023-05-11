
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Educations
{
    public class CreateModel : CreatePageModel <Education>
    {
		public CreateModel(IEducationDataService dataService)
			: base(dataService)
		{ }


	}
}
