public class EditModel : EditPageModel<Instructor>
{
    public EditModel(IInstructorDataService dataService)
        : base(dataService)
    {
    }
}
