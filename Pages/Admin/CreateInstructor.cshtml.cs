public class CreateInstructorModel : CreatePageModel<Instructor>
    {
        public CreateInstructorModel(IInstructorDataService instructorDataService)
            : base(instructorDataService, "/Admin/All")
        {
        }
}


