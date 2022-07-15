using HotelManagement.Data;
using System;
using System.Threading.Tasks;

namespace HotelManagement.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;
        private IRepository<Country> _countries;
        private IRepository<Hotel> _hotels;
        public UnitOfWork(DatabaseContext dbContext) => _dbContext = dbContext;
        public IRepository<Country> Countries => _countries ??= new Repository<Country>(_dbContext);
        public IRepository<Hotel> Hotels => _hotels ??= new Repository<Hotel>(_dbContext);
        public async Task Save() => await _dbContext.SaveChangesAsync();
        public void Dispose()
        {
            this._dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
