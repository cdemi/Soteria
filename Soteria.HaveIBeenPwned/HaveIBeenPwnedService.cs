using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Soteria.HaveIBeenPwned
{
    public class HaveIBeenPwnedService : IHaveIBeenPwnedService
    {
        private readonly HttpClient httpClient;

        public HaveIBeenPwnedService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> IsPasswordBreachedAsync(string password)
        {
            var passwordHash = hash(password);
            var httpResponse = await httpClient.GetAsync($"/range/{passwordHash.Substring(0,5)}");
            var passwordHashRange = (await httpResponse.Content.ReadAsStringAsync()).Split(new string[] { "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var matches = passwordHashRange.Where(ph =>
            {
                var hashAmount = ph.Split(':');
                return passwordHash.Substring(5, passwordHash.Length-5).Equals(hashAmount[0], StringComparison.InvariantCultureIgnoreCase);
            });
            return matches.Count()>0;
        }

        private string hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}
