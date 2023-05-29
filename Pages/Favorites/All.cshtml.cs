using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Pages.Favorites
{
    public class AllModel : FavoritesPageModel
    {
        private readonly IExerciseStatusDataService _exerciseStatusDataService;
        private readonly IExerciseDataService _exerciseDataService;

        public AllModel(IFavoriteDataService favoriteDataService,
                        ICourseDataService courseDataService,
                        IExerciseDataService exerciseDataService,
                        IExerciseStatusDataService exerciseStatusDataService,
                        ELearningDBContext context)
            : base(favoriteDataService, courseDataService, exerciseStatusDataService, context)
        {
            _exerciseDataService = exerciseDataService;
            _exerciseStatusDataService = exerciseStatusDataService;
        }

        public void OnGet()
        {
            LoadFavoriteCourses();
        }



        public async Task<IActionResult> OnPostAddToDoneAsync(int exerciseId)
        {
            if (LogInPageModel.LoggedInUser != null)
            {
                var exerciseStatus = new ExerciseStatus
                {
                    UserId = LogInPageModel.LoggedInUser.Id,
                    ExerciseId = exerciseId,
                    Status = 1
                };

                this._exerciseStatusDataService.Create(exerciseStatus);

                return RedirectToPage("/ExerciseStatuses/All");
            }

            return Unauthorized();
        }
    }
}