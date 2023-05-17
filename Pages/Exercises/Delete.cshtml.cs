using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Exercises
{
	public class DeleteModel : DeletePageModel<Exercise>
	{
		public DeleteModel(IExerciseDataService dataService)
			: base(dataService)
		{
		}
	}
}
