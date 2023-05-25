using Microsoft.EntityFrameworkCore;

public class EFCCourseDataService : EFCDataServiceAppBase<Course>, ICourseDataService
{


    protected override IQueryable<Course> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Course>().Include(c => c.Exercises);
    }


}
