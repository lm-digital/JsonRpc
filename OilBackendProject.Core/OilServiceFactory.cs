using OilBackendProject.Core.Interfaces;
using OilBackendProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilBackendProject.Core
{
    public class OilServiceFactory
    {
        private static string _dataUrl; // = "https://datahub.io/core/oil-prices/r/brent-daily.json";

        public static IOilService Create(string dataUrl)
        {
            _dataUrl = dataUrl;
            return new OilJsonService(_dataUrl);
        }
    }
}
