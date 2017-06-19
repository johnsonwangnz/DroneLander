

using System.Threading.Tasks;

namespace DroneLander.Services
{
    public interface IAuthenticationService
    {
        Task<bool> SignInAsync();
        Task<bool> SignOutAsync();
    }
}
