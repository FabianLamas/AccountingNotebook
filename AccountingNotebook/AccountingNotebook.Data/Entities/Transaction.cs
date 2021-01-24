using AccountingNotebook.Data.Enums;
using System;

namespace AccountingNotebook.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public TransactionType Type { get; set; }
    }
}
