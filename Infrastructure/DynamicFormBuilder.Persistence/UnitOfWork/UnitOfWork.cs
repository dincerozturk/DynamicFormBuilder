using DynamicFormBuilder.Application.Abstraction.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DynamicFormBuilder.Persistence.UnitOfWork
{
    public sealed class UnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
    {
        #region fields

        private readonly TContext _dbContext;
        private readonly ILogger<UnitOfWork<TContext>> _logger;
        private bool _disposed;

        #endregion

        public UnitOfWork(TContext dbContext,
            ILogger<UnitOfWork<TContext>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        #region Transaction Operations.

        /// <summary>
        /// Creates a new transaction to which all retrived repostiores from UOW will write, Will throw an exception if there is an already created transaction.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="InvalidOperationException()"/>
        /// <returns></returns>
        public async Task BeginWritingAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContext.Database.CurrentTransaction is null)
            {
                await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("There is open writing session already, please discard it beffore starting new session.");
            }
        }

        public bool HasTransaction()
        {
            return _dbContext.Database.CurrentTransaction != null;
        }

        /// <summary>
        /// Saves all changes made to the current transaction and writes them to the database with clearing the current transaction, Will throw an exception if there is an already created transaction.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="InvalidOperationException()"/>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation.</returns>
        public async Task CommitWritingsAsync(CancellationToken cancellationToken = default)
        {
            await using var transaction = _dbContext.Database.CurrentTransaction;

            if (transaction is null)
            {
                throw new InvalidOperationException("Can't save changes when the transaction isn't started first");
            }

            try
            {
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UOW: Exception happend while saving transaction {0}, rolling back everything.", transaction.TransactionId);
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        /// <summary>
        /// Discards all the changes in the current transaction and allows for new transaction creation, Will throw an exception if there isn't a created transaction.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="InvalidOperationException()"/>
        /// <returns></returns>
        public async Task DiscardWritingsAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContext.Database.CurrentTransaction is not null)
            {
                await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }
        #endregion;

        #region Disposables
        public void Dispose()
        {
            if (!_disposed)
            {
                _dbContext.Dispose();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                await _dbContext.DisposeAsync().ConfigureAwait(false);
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose();
        }
        #endregion
    }
}
