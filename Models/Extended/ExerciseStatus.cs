
public partial class ExerciseStatus : IHasId, IUpdateFromOther<ExerciseStatus>
{
    public void Update(ExerciseStatus tOther)
    {
        UserId = tOther.UserId;
        ExerciseId = tOther.ExerciseId;
        Status = tOther.Status;
    }
}
