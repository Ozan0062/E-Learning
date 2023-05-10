using Microsoft.AspNetCore.Identity;

public class EFCUserDataService : EFCDataServiceAppBase<User>, IUserDataService
{
    private PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

    public override int Create(User user)
    {
        user.Password = _passwordHasher.HashPassword(user.Email, user.Password);
        return base.Create(user);
    }

    public User? VerifyUser(string providedEmail, string providedPassword)
    {
        User? user = GetAll().FirstOrDefault(u => u.Email == providedEmail);

        if (user == null ||
            _passwordHasher.VerifyHashedPassword(
                providedEmail,
                user.Password,
                providedPassword)
            != PasswordVerificationResult.Success)
            return null;

        return user;
    }



}
