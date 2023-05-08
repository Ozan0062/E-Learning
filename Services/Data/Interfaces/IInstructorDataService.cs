public interface IInstructorDataService : IDataService<Instructor>
{
    /// <summary>
    /// Verifies that a provided user name and password matches a known user profile.
    /// </summary>
    /// <returns>User matching the provided information, otherwise null.</returns>
    Instructor? VerifyInstructor(string providedEmail, string providedPassword);
}

