using System.Threading.Tasks;

namespace Soteria.HaveIBeenPwned
{
    public interface IHaveIBeenPwnedService
    {
        Task<bool> IsPasswordBreached(string password);
    }
}