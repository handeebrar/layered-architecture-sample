using System;

namespace LayeredArchitectureProject.Data.Infrastructure.UnitOfWork.EntityFramework
{
    public class EfUnitOfWorkBase : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public EfUnitOfWorkBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
