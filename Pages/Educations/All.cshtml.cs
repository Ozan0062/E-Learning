using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Learning.Pages.Educations
{
    public class AllModel : GetAllPageModel<Education>
    {
        public AllModel(IEducationDataService dataService)
            : base(dataService)
        {
        }
    }
}
