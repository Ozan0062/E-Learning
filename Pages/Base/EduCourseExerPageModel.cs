using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class EduCourseExerPageModel : PageModel
{
    protected Education GetEducationWithCoursesAndExercises(int educationId)
    {
        using (var context = new ELearningDBContext())
        {
            return context.Educations
                .Include(e => e.Courses)
                .ThenInclude(c => c.Exercises)
                .FirstOrDefault(e => e.Id == educationId);
        }
    }


}
