using AccountingNotebook.Data.Entities;
using AccountingNotebook.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountingNotebook.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<(Transaction, string)> AddTransactionAsync(AccountTransaction model);
    }
}
