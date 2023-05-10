public class EFCInstructorDataService : EFCDataServiceAppBase<Instructor>, IInstructorDataService
{
    public Instructor? VerifyInstructor(string providedEmail, string providedPassword)
    {
        Instructor? instructor = GetAll().FirstOrDefault(i => i.Email == providedEmail);

        if (instructor == null || instructor.Password != providedPassword)
            return null;

        return instructor;
    }
}