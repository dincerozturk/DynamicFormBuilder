namespace DynamicFormBuilder.Application.Abstraction.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginWritingAsync(CancellationToken cancellationToken = default);
        Task CommitWritingsAsync(CancellationToken cancellationToken = default);
        Task DiscardWritingsAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// True ise transaction başlatılmış, false ise transaction başlatılmamıştır.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        bool HasTransaction();

    }
}
