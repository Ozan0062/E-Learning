using Microsoft.EntityFrameworkCore;

public class EFCExerciseDataService : EFCDataServiceAppBase<Exercise>, IExerciseDataService
{
    protected override IQueryable<Exercise> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Exercise>();
    }
}
