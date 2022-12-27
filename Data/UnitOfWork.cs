using Microsoft.EntityFrameworkCore;
using RRHHApi.Helpers;
using RRHHApi.Interfases;

namespace RRHHApi.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ICandidatoRepository candidatoRepository => new CandidatoRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
