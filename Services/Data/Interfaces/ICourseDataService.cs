public interface ICourseDataService : IDataService<Course>
{
    Course GetCourseWithExercises(int courseId);
}
