using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Exercises
{
    public class AllModel : GetAllPageModel<Exercise>
    {
        public AllModel(IExerciseDataService dataService)
            : base(dataService)
        {
        }
    }
}
