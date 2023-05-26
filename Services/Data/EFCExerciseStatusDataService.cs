using Microsoft.EntityFrameworkCore;

public class EFCExerciseStatusDataService : EFCDataServiceAppBase<ExerciseStatus>, IExerciseStatusDataService
{
    public List<ExerciseStatus> ExerciseStatus { get; set; }

    protected override IQueryable<ExerciseStatus> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(f => f.User)
            .Include(f => f.Exercise);
    }

    public List<ExerciseStatus> GetExerciseStatusForUser(int userId)
    {
        using (var context = new ELearningDBContext())
        {
            return context.ExerciseStatuses
                .Where(f => f.UserId == userId)
                .ToList();
        }
    }
}
