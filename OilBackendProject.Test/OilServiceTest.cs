using OilBackendProject.Core;
using OilBackendProject.Core.Models;

namespace OilBackendProject.Test
{
    [TestClass]
    public class OilServiceTest
    {
        [TestMethod]
        public async Task GetSerieForOneDay()
        {
            var service = OilServiceFactory.Create();
            Assert.IsNotNull(service);

            var serie = await service.GetOilPriceTrendAsync("2001-09-26", "2001-09-26");
            Assert.IsTrue(serie.Length == 1, "Non restituisce un elemento");
            Assert.IsTrue(serie[0].Date == "2001-09-26", "Viene restituito elemento con data non corretta");
            Assert.IsTrue(serie[0].Price == 20.67M, "Viene restituito elemento con prezzo non corretto");
        }

        [TestMethod]
        public async Task GetSerieFor5Days()
        {
            var service = OilServiceFactory.Create();
            Assert.IsNotNull(service);
            //{"Date": "2001-09-03", "Price": 26.52},{"Date": "2001-09-04", "Price": 26.27},{"Date": "2001-09-05", "Price": 26.27},{"Date": "2001-09-06", "Price": 26.61},{"Date": "2001-09-07", "Price": 27.54}
            var serie = await service.GetOilPriceTrendAsync("2001-09-03", "2001-09-07");
            var exptected = new OilEntry[5] {
                new OilEntry() { Date = "2001-09-03", Price = 26.52M },
                new OilEntry() { Date = "2001-09-04", Price = 26.27M },
                new OilEntry() { Date = "2001-09-05", Price = 26.27M },
                new OilEntry() { Date = "2001-09-06", Price = 26.61M },
                new OilEntry() { Date = "2001-09-07", Price = 27.54M }
            };
            Assert.IsTrue(serie.Length == 5, "Non restituisce il numero di elementi corretti");

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(exptected[i].Date, serie[i].Date, "Risulato inatteso. Date diverso per l'indice i={0}", i);
                Assert.AreEqual(exptected[i].Price, serie[i].Price, "Risulato inatteso. Price diverso per l'indice i={0}", i);
            }
        }
    }
}