using ExpertsDirectory.API.Utility;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ExpertsDirectory.API.Tests
{
    public class WebScrapperTest
    {
        private WebScrapper _webScrapper;
        [SetUp]
        public void Setup()
        {
            _webScrapper = new WebScrapper();
        }

        [Test]
        public async Task RetrieveHeadersTest()
        {
            var results = await _webScrapper.RetrieveHeaders("https://girliemac.com/");
            Assert.Greater(results.Count, 0);
        }
    }
}