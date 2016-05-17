using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;


namespace Monument.Facade
{
    public class Facade
    {
        private const string serverUrl = "http://localhost:13485";
        //HttpClientHandler handler = new HttpClientHandler();
        //handler.UseDefaultCredentials = true;
        public string ErrorMessage { get; set; }

        //////////////STATUER ///////////////////////

        //http GET - Statuer
        public async Task<List<Statuer>> GetStatuerList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Statuer";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatuerList = await response.Content.ReadAsAsync<List<Statuer>>();
                        return StatuerList;
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

        public async Task<Statuer> GetStatuer(Statuer getStatuer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Statuer/" + getStatuer.Statue_Id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Statuer = await response.Content.ReadAsAsync<Statuer>();
                        return Statuer;
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

        public async Task<Statuer> PostStatuer(Statuer newStatuer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<Statuer>("API/Statuers/", newStatuer);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newStatuer;
                }

                ErrorMessage = response.StatusCode.ToString();
                return null;
                //}
                //catch (Exception e)
                //{
                //    ErrorMessage = e.Message;
                //    return null;
                //}

            }
        }

        //HTTP PUT
        public async Task<Statuer> PutStatuer(Statuer udStatuer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Statuer>("API/Statuer/" + udStatuer.Statue_Id, udStatuer);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udStatuer;
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

        public async Task<Statuer> DeleteStatuer(Statuer delStatuer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Statuer/" + delStatuer.Statue_Id;

                //try
                //{
                HttpResponseMessage response = await client.DeleteAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    ErrorMessage = response.StatusCode.ToString();
                    return null;
                }
                ErrorMessage = response.StatusCode.ToString();
                return null;
                //}
                //catch (Exception e)
                //{
                //    ErrorMessage = e.Message;
                //    return null;
                //}
            }

        }

        ////////////////STATUER END /////////////////





        /////////////////ADRESSE//////////////////

        public async Task<List<Adresse>> GetAdresseList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Adresse";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var AdresseList = await response.Content.ReadAsAsync<List<Adresse>>();
                        return AdresseList;
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

        public async Task<Adresse> GetAdresse(Adresse getAdresse)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Adresse/" + getAdresse.PostNr;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Adresse = await response.Content.ReadAsAsync<Adresse>();
                        return Adresse;
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

        public async Task<Adresse> PostAdresse(Adresse newAdresse)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<Adresse>("API/Adresses/", newAdresse);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newAdresse;
                }

                ErrorMessage = response.StatusCode.ToString();
                return null;
                //}
                //catch (Exception e)
                //{
                //    ErrorMessage = e.Message;
                //    return null;
                //}

            }
        }

        //HTTP PUT
        public async Task<Adresse> PutAdresse(Adresse udAdresse)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Adresse>("API/Adresse/" + udAdresse.PostNr, udAdresse);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udAdresse;
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

        public async Task<Adresse> DeleteAdresse(Adresse delAdresse)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Adresse/" + delAdresse.PostNr;

                //try
                //{
                HttpResponseMessage response = await client.DeleteAsync(urlString);
                if (response.IsSuccessStatusCode)
                {
                    ErrorMessage = response.StatusCode.ToString();
                    return null;
                }
                ErrorMessage = response.StatusCode.ToString();
                return null;
                //}
                //catch (Exception e)
                //{
                //    ErrorMessage = e.Message;
                //    return null;
                //}
            }

        }

        /////////////////ADRESSE end//////////////////
    }
}

