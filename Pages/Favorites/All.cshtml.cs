using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Favorites
{
    public class AllModel : GetAllPageModel<Favorite>
    {
        public AllModel(IFavoriteDataService dataService)
            : base(dataService)
        { 
        }
    }
}
