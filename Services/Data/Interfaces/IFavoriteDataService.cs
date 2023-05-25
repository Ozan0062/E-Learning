public interface IFavoriteDataService : IDataService<Favorite>
{
    List<Favorite> Favorite { get; } // Egenskab til at få adgang til favoritter
    List<Favorite> GetFavoritesForUser(int userId); // Metode til at hente favoritter for en specifik bruger
}
