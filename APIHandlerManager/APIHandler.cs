using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Assignment_4.Models;

namespace Assignment_4.APIHandlerManager
{
  public class APIHandler
  {
    // Obtaining the API key is easy. The same key should be usable across the entire
    // data.gov developer network, i.e. all data sources on data.gov.
    // https://www.nps.gov/subjects/developer/get-started.htm

    static string BASE_URL = "https://api.fda.gov/animalandveterinary/event.json";
    static string API_KEY = "JdOj6U8yiAdhOSTZN8UgAhr0hlNapQCwBxUwpmnn"; //Add your API key here inside ""

    HttpClient httpClient;

    /// <summary>
    ///  Constructor to initialize the connection to the data source
    /// </summary>
    public APIHandler()
    {
      httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
      httpClient.DefaultRequestHeaders.Accept.Add(
          new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

        public List<Result> GetData()
        {
            string API_PATH = BASE_URL + "?search=outcome.medical_status:%22Died%22+AND+animal.species:%22Cat%22&limit=100";
            string catsData = "";

            RootObject data1 = null;

            httpClient.BaseAddress = new Uri(API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    catsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!catsData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    data1 = JsonConvert.DeserializeObject<RootObject>(catsData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return data1.results;
        }
    }
}