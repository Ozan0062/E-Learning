using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DeleteModel : DeletePageModel<Instructor>
{
    public DeleteModel(IInstructorDataService dataService)
        : base(dataService)
    {
    }
}
