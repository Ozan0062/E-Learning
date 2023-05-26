
public interface IExerciseDataService : IDataService<Exercise>
{
    Exercise GetExerciseWithExerciseDone(int exerciseId);
}
