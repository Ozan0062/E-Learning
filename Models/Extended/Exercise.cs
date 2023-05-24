using System.ComponentModel.DataAnnotations;

public partial class Exercise : IHasId, IUpdateFromOther<Exercise>
{

    public void Update(Exercise tOther)
    {
        Name = tOther.Name;
        Purpose = tOther.Purpose;
        Description = tOther.Description;
        CourseId = tOther.CourseId;
        FileName = tOther.FileName;
        ContentType = tOther.ContentType;
        Data = tOther.Data;
    }
}
