using Microsoft.EntityFrameworkCore;

public class EFCFavoriteDataService : EFCDataServiceAppBase<Favorite>, IFavoriteDataService
{
    public List<Favorite> Favorite { get; set; }

    public EFCFavoriteDataService()
    {
        Favorite = new List<Favorite>(); // Initialize the Favorite property with an empty list
    }

    protected override IQueryable<Favorite> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(f => f.User)
            .Include(f => f.Course);
    }
}
