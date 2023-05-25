using Microsoft.EntityFrameworkCore;

public class EFCExerciseStatusDataService : EFCDataServiceAppBase<ExerciseStatus>, IExerciseStatusDataService
{
    public List<ExerciseStatus> ExerciseStatus { get; set; }

    public EFCExerciseStatusDataService()
    {
        ExerciseStatus = new List<ExerciseStatus>(); // Initialize the Favorite property with an empty list
    }

    protected override IQueryable<ExerciseStatus> GetAllWithIncludes(DbContext context)
    {
        return base.GetAllWithIncludes(context)
            .Include(f => f.User)
            .Include(f => f.Exercise);
    }

    public List<ExerciseStatus> GetExerciseStatusForUser(int userId)
    {
        return ExerciseStatus
            .Where(f => f.UserId == userId)
            .ToList();
    }

}
