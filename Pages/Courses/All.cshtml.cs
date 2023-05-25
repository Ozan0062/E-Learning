using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Pages.Courses
{
    // h
    public class AllModel : GetAllPageModel<Course>
    {
		private readonly IFavoriteDataService favoriteDataService;

		public AllModel(ICourseDataService dataService, IFavoriteDataService favoriteDataService)
            : base(dataService)
        {
			this.favoriteDataService = favoriteDataService;
		}

        public async Task<IActionResult> OnPostAddToFavoritesAsync(int courseId)
        {
            // Tjek om brugeren er logget ind
            if (LogInPageModel.LoggedInUser != null)
            {
                // Opret en ny favoritlinje i din favorites-tabel
                var favorite = new Favorite
                {
                    UserId = LogInPageModel.LoggedInUser.Id, // Brug brugerens ID
                    CourseId = courseId // Brug det kursus-ID, der er forbundet med knappen
                };

                // Gem favoritten i din database eller foretag de n�dvendige handlinger
                // f.eks. ved hj�lp af en service eller repository
                this.favoriteDataService.Create(favorite);

                // Tilf�j logik for at h�ndtere succes eller fejl ved at tilf�je favorit

                // Returner et passende IActionResult-objekt
                return RedirectToPage("/Profile/ProfilePage"); // Eksempelvis omdirigering til kursusoversigten
            }

            // H�ndter tilf�lde, hvor brugeren ikke er logget ind
            return Unauthorized();
        }
    }
}
