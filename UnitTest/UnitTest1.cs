using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMCTaxApp.Methods;
using System.Threading.Tasks;

namespace IMCTaxApp_UnitTests
{
    [TestClass]
    public class IMCTaxApp_IMCTaxAppMethods
    {
        IMCTaxAppMethods ita = new IMCTaxAppMethods();

        /// <summary>
        /// Very basic test... 
        /// if any result object is null then there was an error
        /// </summary>
        [TestMethod]
        public async Task Test_GetTaxRatesForLocation()
        {
            var result = await ita.GetTaxRatesForLocation();

            Assert.IsNotNull(result.rate);
        }

        /// <summary>
        /// Very basic test... 
        /// if any result object is null then there was an error
        /// </summary>
        [TestMethod]
        public async Task Test_GetCalcTaxesForAnOrder()
        {
            var result = await ita.GetCalcTaxesForAnOrder();

            Assert.IsNotNull(result.tax);
        }
    }
}
