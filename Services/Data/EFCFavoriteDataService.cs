using Microsoft.EntityFrameworkCore;

public class EFCFavoriteDataService : EFCDataServiceAppBase<Favorite>, IFavoriteDataService
{
    protected override IQueryable<Favorite> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Favorite>()
            .Include(o => o.User)
            .Include(o => o.Course);
    }
}