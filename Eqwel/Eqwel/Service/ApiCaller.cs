using System.Net.Http;
using System.Threading.Tasks;

namespace Eqwel.Service
{
    public class ApiCaller
    {
        public static async Task<string> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(url);

                return request.IsSuccessStatusCode ? await request.Content.ReadAsStringAsync() : null;
            }
        }
    }
}
