
public partial class User : IHasId, IUpdateFromOther<User>
{
    public void Update(User tOther)
    {
        Email = tOther.Email;
        Password = tOther.Password;
    }
}

