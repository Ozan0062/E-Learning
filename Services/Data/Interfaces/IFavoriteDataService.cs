public interface IFavoriteDataService : IDataService<Favorite>
{
    List<Favorite> Favorite { get; } // Egenskab til at få adgang til favoritter
}
