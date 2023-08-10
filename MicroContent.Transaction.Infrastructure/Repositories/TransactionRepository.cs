using MicroContent.Transactions.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MicroContent.Transactions.Infrastructure.Repositories;

public class TransactionRepository : Domain.Interface.Transactions.IRepository<Transaction>
{
    private readonly string connectionString =
        "data source=DESKTOP-4LM8G0M;initial catalog=CryptoDB;trusted_connection=true;Trust Server Certificate = true";
    public async Task<IEnumerable<Transaction>> GetAll()
    {
        string sql = $" SELECT TransactionID ,AdressFrom ,AdressTo ,LocationByIP ,Country ,IsFirstAdressTransaction ,TransactionDate FROM[dbo].[Transactions]";
        ICollection<Transaction> transactions;

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            transactions = connection.Query<Transaction>(sql).ToList();
            connection.Close();
        }
        
        return transactions.AsEnumerable();
    }

    public async Task Save(string adressFrom, string adressTo, string location)
    {
        throw new NotImplementedException();
    }
}