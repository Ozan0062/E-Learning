
public partial class User : IHasId, IUpdateFromOther<User>
{
    public void Update(User tOther)
    {
        Name = tOther.Name;
        Email = tOther.Email;
        Password = tOther.Password;
        City = tOther.City;
        PhoneNumber = tOther.PhoneNumber;
        PostalCode = tOther.PostalCode;
    }
}

public partial class Admin : IHasId, IUpdateFromOther<Admin>
{
    public void Update(Admin tOther)
    {
        Name = tOther.Name;
        Email = tOther.Email;
        Password = tOther.Password;
        PhoneNumber = tOther.PhoneNumber;
    }
}

public partial class Instructor : IHasId, IUpdateFromOther<Instructor>
{
    public void Update(Instructor tOther)
    {
        Name = tOther.Name;
        Email = tOther.Email;
        Password = tOther.Password;
        PhoneNumber = tOther.PhoneNumber;
    }
}
