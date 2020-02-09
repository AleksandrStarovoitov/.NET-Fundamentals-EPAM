namespace ClassLibrary.BL.Interfaces
{
    public interface IIncludeAsyncRepository<T> : IAsyncRepository<T>, IGetWithIncludeAsyncRepository<T>
        where T : class, IEntity
    {
    }
}