using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;

public class InstructorProfilePageModel : PageModel
{
	private readonly IInstructorDataService _instructorDataService;

	public InstructorProfilePageModel(IInstructorDataService instructorDataService)
	{
		_instructorDataService = instructorDataService;
	}

	public Instructor LoggedInInstructor { get; set; }

	public void OnGet(int instructorId)
	{
		instructorId = InstructorLogInModel.LoggedInInstructor.Id;
	}
}