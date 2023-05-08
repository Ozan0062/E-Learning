public class RegisterPageModel : CreatePageModel<User>
{
    public RegisterPageModel(IUserDataService userDataService)
        : base(userDataService, "/Index")
    {
    }
}

