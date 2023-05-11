
public partial class Course : IHasId, IUpdateFromOther<Course>
{
    public void Update(Course tOther)
    {
        EducationId= tOther.EducationId;
        Name = tOther.Name;
        Description = tOther.Description;
        Education = tOther.Education;

    }
}

