using OilBackendProject.Core.Interfaces;
using OilBackendProject.Core.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OilBackendProject.Core.Services
{
    public class OilJsonService : IOilService
    {
        private string _dataUrl;
        public OilJsonService(string dataUrl)
        {
            _dataUrl = dataUrl;
        }

        public async Task<OilEntry[]> GetOilPriceTrendAsync(string fromDate, string toDate)
        {

            DateTime from = DateTime.Parse(fromDate);
            DateTime to = DateTime.Parse(toDate);
            using var client = new HttpClient();
            var jsonData = await client.GetStringAsync(_dataUrl);

            using var document = JsonDocument.Parse(jsonData);

            var query = document.RootElement.EnumerateArray().Where(i =>
                i.GetProperty("Date").GetDateTime() >= from &&
                i.GetProperty("Date").GetDateTime() <= to);

            return query.Select(i => new OilEntry() { Date = i.GetProperty("Date").GetString(), Price = i.GetProperty("Price").GetDecimal() }).ToArray();
        }
    }
}
