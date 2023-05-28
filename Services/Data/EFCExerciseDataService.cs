using Microsoft.EntityFrameworkCore;

public class EFCExerciseDataService : EFCDataServiceAppBase<Exercise>, IExerciseDataService
{
    protected override IQueryable<Exercise> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Exercise>().Include(e => e.Course).Include(e => e.Course.Education);
    }

    public Exercise GetExerciseWithExerciseDone(int exerciseId)
    {
        using (var context = new ELearningDBContext())
        {
            var exerciseStatus = context.ExerciseStatuses
                .FirstOrDefault(f => f.ExerciseId == exerciseId && f.Status == 1); // Assuming that Status == 1 means the exercise is done.

            return exerciseStatus != null ? context.Exercises.Include(e => e.Course).FirstOrDefault(e => e.Id == exerciseStatus.ExerciseId) : null;
        }
    }
}