using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Exercises
{
	public class ViewModel : ViewPageModel<Exercise>
	{
		public ViewModel(IExerciseDataService dataService)
			: base(dataService)
		{
		}
	}
}
