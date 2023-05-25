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

                // Gem favoritten i din database eller foretag de nødvendige handlinger
                // f.eks. ved hjælp af en service eller repository
                this.favoriteDataService.Create(favorite);

                // Tilføj logik for at håndtere succes eller fejl ved at tilføje favorit

                // Returner et passende IActionResult-objekt
                return RedirectToPage("/Profile/ProfilePage"); // Eksempelvis omdirigering til kursusoversigten
            }

            // Håndter tilfælde, hvor brugeren ikke er logget ind
            return Unauthorized();
        }
    }
}
