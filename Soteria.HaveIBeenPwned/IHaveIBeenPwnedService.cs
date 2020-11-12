using System.Threading.Tasks;

namespace Soteria.HaveIBeenPwned
{
    public interface IHaveIBeenPwnedService
    {
        Task<bool> IsPasswordBreachedAsync(string password);
    }
}