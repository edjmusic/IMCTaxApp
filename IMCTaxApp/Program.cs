using System.Threading.Tasks;
using IMCTaxApp.Methods;

namespace IMCTaxApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMCTaxAppMethods ita = new IMCTaxAppMethods();

            await ita.GetTaxRatesForLocation();

            await ita.GetCalcTaxesForAnOrder();
        }

       
    }
}
