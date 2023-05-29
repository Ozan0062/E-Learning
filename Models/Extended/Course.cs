public partial class Course : IHasId, IUpdateFromOther<Course>
{
    public void Update(Course other)
    {
        Name = other.Name;
        Description = other.Description;
        EducationId = other.EducationId;
    }
}
