public interface IFavoriteDataService : IDataService<Favorite>
{
    List<Favorite> Favorite { get; } 
    List<Favorite> GetFavoritesForUser(int userId); 

}
