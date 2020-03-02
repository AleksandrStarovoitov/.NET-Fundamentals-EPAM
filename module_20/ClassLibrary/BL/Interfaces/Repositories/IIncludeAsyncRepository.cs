namespace ClassLibrary.BL.Interfaces.Repositories
{
    public interface IIncludeAsyncRepository<T> : IAsyncRepository<T>, IGetWithIncludeAsyncRepository<T>
        where T : class, IEntity
    {
    }
}