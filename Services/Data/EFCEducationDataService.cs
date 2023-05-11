using Microsoft.EntityFrameworkCore;

public class EFCEducationDataService : EFCDataServiceAppBase<Education>, IEducationDataService
{
	protected override IQueryable<Education> GetAllWithIncludes(DbContext context)
	{
		return context.Set<Education>();
	}
}
