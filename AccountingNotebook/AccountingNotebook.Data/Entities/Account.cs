using System;
using System.Collections.Generic;
using System.Threading;

namespace AccountingNotebook.Data.Entities
{
    public class Account
    {
        private double _balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();
        private ReaderWriterLockSlim _locked = new ReaderWriterLockSlim();
        private static readonly Account Instance = new Account();

        public double GetBalance()
        {
            _locked.EnterReadLock();
            try
            {
                return _balance;
            }
            finally
            {
                _locked.ExitReadLock();
            }
        }
        public List<Transaction> GetTransactions()
        {
            try
            {
                _locked.EnterReadLock();
                return _transactions;
            }
            finally
            {
                _locked.ExitReadLock();
            }
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            try
            {
                _locked.EnterWriteLock();
                transaction.Id = _transactions.Count + 1;
                transaction.EffectiveDate = DateTime.Now;

                _transactions.Add(transaction);
                if(transaction.Type == Enums.TransactionType.Credit)
                {
                    _balance += transaction.Amount;
                }
                else
                {
                    _balance -= transaction.Amount;
                }

                return transaction;
            }
            finally
            {
                _locked.ExitWriteLock();
            }
        }

        public static Account GetInstance()
        {
            return Instance;
        }
    }
}
