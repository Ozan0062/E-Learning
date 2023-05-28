public class AllModel : GetAllPageModel<Instructor>
{
	public AllModel(IInstructorDataService instructorDataService)
		: base(instructorDataService)
	{
	}
}
