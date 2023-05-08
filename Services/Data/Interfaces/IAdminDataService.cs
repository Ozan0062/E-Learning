public interface IAdminDataService : IDataService<Admin>
{
    /// <summary>
    /// Verifies that a provided user name and password matches a known user profile.
    /// </summary>
    /// <returns>User matching the provided information, otherwise null.</returns>
    Admin? VerifyAdmin(string providedEmail, string providedPassword);
}

