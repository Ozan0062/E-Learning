public class EFCUserDataService : EFCDataServiceAppBase<User>, IUserDataService
{
    public User? VerifyUser(string providedEmail, string providedPassword)
    {
        User? user = GetAll().FirstOrDefault(e => e.Email == providedEmail);

        if (user == null || user.Password != providedPassword)
            return null;

        return user;
    }
}
