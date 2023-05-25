
public partial class Course : IHasId, IUpdateFromOther<Course>
{
    public Course()
    {
        this.Exercises = new HashSet<Exercise>();
    }
    public void Update(Course tOther)
    {
        Name = tOther.Name;
        Description = tOther.Description;
        EducationId = tOther.EducationId; 
    }


}

