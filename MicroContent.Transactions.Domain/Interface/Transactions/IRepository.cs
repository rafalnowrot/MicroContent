namespace MicroContent.Transactions.Domain.Interface.Transactions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task Save(string adressFrom, string adressTo, string location);
}