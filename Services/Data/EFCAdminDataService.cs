public class EFCAdminDataService : EFCDataServiceAppBase<Admin>, IAdminDataService
{
    public Admin? VerifyAdmin(string providedEmail, string providedPassword)
    {
        Admin? admin = GetAll().FirstOrDefault(a => a.Email == providedEmail);

        if (admin == null || admin.Password != providedPassword)
            return null;

        return admin;
    }
}