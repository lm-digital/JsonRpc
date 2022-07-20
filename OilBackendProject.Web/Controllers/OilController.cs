using Microsoft.AspNetCore.Mvc;
using OilBackendProject.Core.Interfaces;
using OilBackendProject.Web.Models;
using Tochka.JsonRpc.Server.Attributes;
using Tochka.JsonRpc.Server.Pipeline;
using Tochka.JsonRpc.Server.Settings;

namespace OilBackendProject.Web.Controllers
{

    public class OilController : JsonRpcController
    {

        private readonly IOilService _oilService;

        public OilController(IOilService oilService)
        {
            this._oilService = oilService;
        }

        public async Task<GetOilPriceTrendResponse> GetOilPriceTrend([FromParams(BindingStyle.Object)] GetOilPriceTrendRequest data) {

            var result = await _oilService.GetOilPriceTrendAsync(data.StartDateISO8601, data.EndDateISO8601);
            return new GetOilPriceTrendResponse() { 
                Prices = result.Select(i => new GetOilPriceTrendResponse.SeriesItem() { DateISO8601 = i.Date, Price = i.Price }).ToList() 
            };
        }

    }
   
}
