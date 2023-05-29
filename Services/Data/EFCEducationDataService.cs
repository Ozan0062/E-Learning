using Microsoft.EntityFrameworkCore;

public class EFCEducationDataService : EFCDataServiceAppBase<Education>, IEducationDataService
{
    protected override IQueryable<Education> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Education>()
            .Include(e => e.Courses)
            .ThenInclude(c => c.Exercises);
    }
}
