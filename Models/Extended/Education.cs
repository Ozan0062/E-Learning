
	public partial class Education : IHasId, IUpdateFromOther<Education>
	{

	public void Update(Education tOther)
	{
		Name = tOther.Name;
	}
}
