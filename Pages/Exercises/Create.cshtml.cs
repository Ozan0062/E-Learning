using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Exercises
{
    public class CreateModel : CreatePageModel<Exercise>
    {
        public CreateModel(IExerciseDataService dataService)
            : base(dataService)
        {
        }
    }
}
