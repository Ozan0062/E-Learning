using Microsoft.EntityFrameworkCore;
using System.Linq;

public class EFCFavoriteDataService : EFCDataServiceAppBase<Favorite>, IFavoriteDataService
{
    private readonly ELearningDBContext _context;

    public EFCFavoriteDataService(ELearningDBContext context)
    {
        _context = context;
    }

    protected override IQueryable<Favorite> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(f => f.User)
            .Include(f => f.Course);
    }

    public List<Favorite> GetFavoritesForUser(int userId)
    {
        return _context.Favorites
            .Where(f => f.UserId == userId)
            .ToList();
    }
}
