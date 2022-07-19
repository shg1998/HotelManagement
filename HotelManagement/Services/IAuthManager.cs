using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDto);
        Task<string> CreateToken();
    }
}
