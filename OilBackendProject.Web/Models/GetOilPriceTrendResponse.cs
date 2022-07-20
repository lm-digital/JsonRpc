namespace OilBackendProject.Web.Models
{
    public class GetOilPriceTrendResponse
    {
        public ICollection<SeriesItem> Prices { get; set; }

        public class SeriesItem {

            public string DateISO8601 { get; set; }
            public decimal Price { get; set; }
        }
    }
}
