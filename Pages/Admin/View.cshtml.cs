public class ViewModel : ViewPageModel<Instructor>
{
	public ViewModel(IInstructorDataService dataService)
		: base(dataService)
	{
	}
}
