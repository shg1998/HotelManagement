using System;
using System.Threading.Tasks;
using HotelManagement.Data;

namespace HotelManagement.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Country> Countries { get; }
        IRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
