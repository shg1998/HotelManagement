using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto userDto);
        Task<string> CreateToken();
    }
}
