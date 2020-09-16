using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using IMCTaxApp.Models;
using IMCTaxApp.Models.CalculateTaxReturnModel;

namespace IMCTaxApp.Methods
{
    public class IMCTaxAppMethods
    {
        private readonly HttpClient client = new HttpClient();

        public IMCTaxAppMethods()
        {
            Console.WriteLine("hi");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "5da2f821eee4035db4771edab942a4cc");
        }

        /// <summary>
        /// Sends a GET with a zipcode parameter
        /// </summary>
        /// <returns>TaxRateReturnModel object</returns>
        public async Task<TaxRateReturnModel> GetTaxRatesForLocation()
        {
            try
            {
                // TODO: hardcoded for this test
                string zipcode = "30017";

                var jsonString = await client.GetStringAsync(String.Format("https://api.taxjar.com/v2/rates/{0}", zipcode));

                Console.Write(jsonString);

                return JsonConvert.DeserializeObject<TaxRateReturnModel>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Reads test input JSON for POST in body from file, 
        /// converts JSON to StringContent object,
        /// uses HttpClient to post and return a response,
        /// pulls returned JSON text into string = result
        /// </summary>
        /// <returns>CalculateTaxReturnModel object</returns>
        public async Task<CalculateTaxReturnModel> GetCalcTaxesForAnOrder()
        {
            try
            {
                //TODO: path should be a parameter or setting
                string pathTo = Directory.GetCurrentDirectory() + "/TestData/CalcTaxesPostData.json";
                string srFile = File.OpenText(@pathTo).ReadToEnd();

                var data = new StringContent(srFile, Encoding.UTF8, "application/json");

                // TODO: store url in settings
                var url = "https://api.taxjar.com/v2/taxes";

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;

                Console.Write(result);

                return JsonConvert.DeserializeObject<CalculateTaxReturnModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
