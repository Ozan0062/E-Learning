public interface IExerciseStatusDataService : IDataService<ExerciseStatus>
{
    List<ExerciseStatus> ExerciseStatus { get; } // Egenskab til at få adgang til favoritter
    List<ExerciseStatus> GetExerciseStatusForUser(int userId); // Metode til at hente favoritter for en specifik bruger
}
