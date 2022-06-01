using System;
using Database.Data;
using Database.Interfaces;
using Domain.Entities;

namespace Database.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ExpanseContext context) : base(context)
        {
        }
    }
}

