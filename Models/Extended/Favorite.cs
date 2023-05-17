
    public partial class Favorite : IHasId , IUpdateFromOther<Favorite>
    {
        public void Update(Favorite tOther)
        {
            UserId = tOther.UserId;
            CourseId = tOther.CourseId;
        }
    }
