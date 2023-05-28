
public partial class Course : IHasId, IUpdateFromOther<Course>
{
    public void Update(Course tOther)
    {
        Name = tOther.Name;
        Description = tOther.Description;
        EducationId = tOther.EducationId; 
    }


}

