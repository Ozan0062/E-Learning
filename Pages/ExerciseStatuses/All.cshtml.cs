using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.ExerciseStatuses
{
    public class AllModel : PageModel
    {
        public List<Exercise> FavoriteExercisesDone { get; set; } = new List<Exercise>();

        public void OnGet()
        {
        }
    }
}