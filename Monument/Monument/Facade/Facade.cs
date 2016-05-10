using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Monument.Models;

namespace Monument.Facade
{
    public class Facade
    {
        private const string serverUrl = "http://localhost:4583";
        //HttpClientHandler handler = new HttpClientHandler();
        //handler.UseDefaultCredentials = true;
        public string ErrorMessage { get; set; }


        //http GET - Statue
        public async Task<List<Statue>> GetStatueList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/statuer";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var statueList = await response.Content.ReadAsAsync<List<Statue>>();
                        return statueList;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    return null;
                }
            }
        }

        public async Task<Statue> GetStatue(Statue getStatue)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/statue/" + getStatue.Statue_Id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var statue = await response.Content.ReadAsAsync<Statue>();
                        return statue;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    return null;
                }
            }
        }

        //Http POST



        public async Task<Statue> PostStatue(Statue newStatue)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = await client.PostAsJsonAsync<Statue>("API/Statuer", newStatue);
                    if (response.IsSuccessStatusCode)
                    {
                        //return MyNewGuest;
                        ErrorMessage = response.StatusCode.ToString();
                        return newStatue;
                    }

                    ErrorMessage = response.StatusCode.ToString();
                    return null;
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    return null;
                }

            }
        }

        //HTTP PUT
        public async Task<Statue> PutStatue(Statue udStatue)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Statue>("API/Statuer/" + udStatue.Statue_Id, udStatue);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udStatue;
                    }
                    ErrorMessage = response.StatusCode.ToString();
                    return null;
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    return null;
                }
            }
        }



        // Http Delete

        public async Task<Statue> DeleteStatue(Statue delStatue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Statuer/" + delStatue.Statue_Id;

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(urlString);
                    if (response.IsSuccessStatusCode)
                    {
                        ErrorMessage = response.StatusCode.ToString();
                        return null;
                    }
                    ErrorMessage = response.StatusCode.ToString();
                    return null;
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    return null;
                }
            }

        }
    }
}
