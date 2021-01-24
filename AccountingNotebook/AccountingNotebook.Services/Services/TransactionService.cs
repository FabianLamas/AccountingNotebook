using AccountingNotebook.Data.Entities;
using AccountingNotebook.Data.Models;
using AccountingNotebook.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly Account _account;

        public TransactionService()
        {
            _account = Account.GetInstance();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            var result = _account.GetTransactions();
            return result.Select(x => new Transaction { Id = x.Id, Amount = x.Amount, EffectiveDate = x.EffectiveDate, Type = x.Type });
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            var result = _account.GetTransactions();
            return result.FirstOrDefault(x => x.Id == id);
        }

        public async Task<(Transaction, string)> AddTransactionAsync(AccountTransaction model)
        {
            if (model.Amount == 0)
            {
                return (null, "Amount cannot be 0");
            }
            if (await CalculateBalance(model) < 0)
            {
                return (null, "Insufficient balance");
            }

            var entity = new Transaction { Type = model.Type, Amount = model.Amount };
            var result = _account.CreateTransaction(entity);

            return (new Transaction { Amount = result.Amount, EffectiveDate = result.EffectiveDate, Id = result.Id, Type = result.Type }, null);
        }


        private async Task<double> CalculateBalance(AccountTransaction model)
        {
            var currentBalance = _account.GetBalance();
     
            if(model.Type == Data.Enums.TransactionType.Credit)
            {
                return currentBalance + model.Amount;
            }
            else
            {
                return currentBalance - model.Amount;
            }
        }
    }
}
