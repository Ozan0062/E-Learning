public class AllModel : GetAllPageModel<Instructor>
{
	public AllModel(IInstructorDataService dataService)
		: base(dataService)
	{
	}
}
