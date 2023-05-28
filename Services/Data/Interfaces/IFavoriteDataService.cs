public interface IFavoriteDataService : IDataService<Favorite>
{
    List<Favorite> GetFavoritesForUser(int userId); 

}
