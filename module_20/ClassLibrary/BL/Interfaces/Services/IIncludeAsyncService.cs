namespace ClassLibrary.BL.Interfaces.Services
{
    public interface IIncludeAsyncService<T> : IAsyncService<T>, IGetWithIncludeAsyncRepository<T>
        where T : class, IEntity
    {
    }
}