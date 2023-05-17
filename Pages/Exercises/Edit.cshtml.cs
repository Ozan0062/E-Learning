using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Exercises
{
	public class EditModel : EditPageModel<Exercise>
	{
		public EditModel(IExerciseDataService dataService)
			: base(dataService)
		{
		}
	}
}
