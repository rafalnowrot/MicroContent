namespace MicroContent.Products.Domain.Interface;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task Save(T request);
    Task Delete(T request);
    Task Update(T request);
    Task GetById(Guid id);
    Task GetById(int id);
}