using Microsoft.EntityFrameworkCore;

public class EFCFavoriteDataService : EFCDataServiceAppBase<Favorite>, IFavoriteDataService
{

	protected override IQueryable<Favorite> GetAllWithIncludes(DbContext context)
	{
		return base.GetAllWithIncludes(context)
			.Include(f => f.User)
			.Include(f => f.Course);
	}
}
