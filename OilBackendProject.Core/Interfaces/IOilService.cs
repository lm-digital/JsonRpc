using OilBackendProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilBackendProject.Core.Interfaces
{
    public interface IOilService
    {
        public Task<OilEntry[]> GetOilPriceTrendAsync(string fromDate, string toDate);
    }
}
