using Microsoft.EntityFrameworkCore;

public class EFCCourseDataService : EFCDataServiceAppBase<Course>, ICourseDataService
{


    protected override IQueryable<Course> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Course>().Include(c => c.Exercises);
    }


    public Course GetCourseWithExercises(int courseId)
    {
        using (var context = new ELearningDBContext())
        {
            return context.Courses
                .Include(c => c.Exercises)
                .FirstOrDefault(c => c.Id == courseId);
        }
    }

}
