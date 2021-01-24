using AccountingNotebook.Data.Enums;

namespace AccountingNotebook.Data.Models
{
    public class AccountTransaction
    {
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
    }
}
