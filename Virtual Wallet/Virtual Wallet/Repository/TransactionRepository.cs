using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.Helpers.Exceptions;
using Virtual_Wallet.Repository.Contracts;

namespace Virtual_Wallet.Repository
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly WalletContext context;

		public TransactionRepository(WalletContext context) 
		{
			this.context = context;
		}
		public async Task<Transaction> GetTransactionById(int id)
		{
			var transaction = await this.context.Transactions.FindAsync(id);
			if (transaction == null)
			{
				throw new EntityNotFoundException($"Transaction with ID {id} not found.");
			}
			return transaction;
		}
		public async Task<PageResult<Transaction>> GetAllTransactionsForUser(int userId, int pageNumber, int pageSize = 10)
		{
			var query = this.context.Transactions
						.Where(t => t.SenderId == userId || t.RecipientId == userId);

			int count = await query.CountAsync();

			var items = await query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return new PageResult<Transaction>(items, count, pageNumber, pageSize);
		}
		public async Task<Transaction> AddTransaction(Transaction transaction)
		{
			var result = await this.context.Transactions.AddAsync(transaction);
			await this.context.SaveChangesAsync();
			return result.Entity;
		}
		public async Task<Transaction> UpdateTransaction(Transaction transaction)
		{
			this.context.Entry(transaction).State = EntityState.Modified;
			await this.context.SaveChangesAsync();
			return transaction;
		}

		public async Task DeleteTransaction(int id)
		{
			var transaction = await this.context.Transactions.FindAsync(id);
			if (transaction != null)
			{
				this.context.Transactions.Remove(transaction);
				await this.context.SaveChangesAsync();
			}
		}
	}
}
