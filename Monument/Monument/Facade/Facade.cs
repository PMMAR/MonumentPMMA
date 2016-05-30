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
                string urlString = "api/Statuers";

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
                string urlString = "api/Statuers/" + getStatuer.Statue_Id;

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
                var response = await client.PostAsJsonAsync<Statuer>("api/Statuers", newStatuer);
                try
                {
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

        //HTTP PUT
        public async Task<Statuer> PutStatuer(Statuer udStatuer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Statuer>("API/Statuers/" + udStatuer.Statue_Id, udStatuer);
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

                string urlString = "api/Statuers/" + delStatuer.Statue_Id;

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
        /// 
        /// 
        /////////////////Materialer//////////////////

        public async Task<List<Materialer>> GetMaterialerList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Materialer";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var MaterialerList = await response.Content.ReadAsAsync<List<Materialer>>();
                        return MaterialerList;
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

        public async Task<Materialer> GetMaterialer(Materialer getMaterialer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Materialer/" + getMaterialer.Materiale_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Materialer = await response.Content.ReadAsAsync<Materialer>();
                        return Materialer;
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

        public async Task<Materialer> PostMaterialer(Materialer newMaterialer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<Materialer>("API/Materialers/", newMaterialer);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newMaterialer;
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
        public async Task<Materialer> PutMaterialer(Materialer udMaterialer)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Materialer>("API/Materialer/" + udMaterialer.Materiale_id, udMaterialer);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udMaterialer;
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

        public async Task<Materialer> DeleteMaterialer(Materialer delMaterialer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Materialer/" + delMaterialer.Materiale_id;

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

        /////////////////Materialer end//////////////////
        /// 
        /// 
        /////////////////StatuerType//////////////////

        public async Task<List<StatuerType>> GetStatuerTypeList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/StatueTypes";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatuerTypeList = await response.Content.ReadAsAsync<List<StatuerType>>();
                        return StatuerTypeList;
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

        public async Task<StatuerType> GetStatuerType(StatuerType getStatuerType)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/StatueTypes/" + getStatuerType.StatuerType_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatuerType = await response.Content.ReadAsAsync<StatuerType>();
                        return StatuerType;
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

        public async Task<StatuerType> PostStatuerType(StatuerType newStatuerType)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<StatuerType>("API/StatueTypes/", newStatuerType);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newStatuerType;
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
        public async Task<StatuerType> PutStatuerType(StatuerType udStatuerType)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<StatuerType>("API/StatueTypes/" + udStatuerType.StatuerType_id, udStatuerType);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udStatuerType;
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

        public async Task<StatuerType> DeleteStatuerType(StatuerType delStatuerType)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/StatueTypes/" + delStatuerType.StatuerType_id;

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

        /////////////////StatuerType end//////////////////
        /// 
        /// 
        ///       /////////////////StatuerPlacering//////////////////

        public async Task<List<StatuerPlacering>> GetStatuerPlaceringList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/StatuePlacerings";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatuerPlaceringList = await response.Content.ReadAsAsync<List<StatuerPlacering>>();
                        return StatuerPlaceringList;
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

        public async Task<StatuerPlacering> GetStatuerPlacering(StatuerPlacering getStatuerPlacering)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/StatuePlacerings/" + getStatuerPlacering.StatuerPlacering_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatuerPlacering = await response.Content.ReadAsAsync<StatuerPlacering>();
                        return StatuerPlacering;
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

        public async Task<StatuerPlacering> PostStatuerPlacering(StatuerPlacering newStatuerPlacering)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<StatuerPlacering>("API/StatuePlacerings/", newStatuerPlacering);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newStatuerPlacering;
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
        public async Task<StatuerPlacering> PutStatuerPlacering(StatuerPlacering udStatuerPlacering)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<StatuerPlacering>("API/StatuePlacerings/" + udStatuerPlacering.StatuerPlacering_id, udStatuerPlacering);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udStatuerPlacering;
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

        public async Task<StatuerPlacering> DeleteStatuerPlacering(StatuerPlacering delStatuerPlacering)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/StatuePlacerings/" + delStatuerPlacering.StatuerPlacering_id;

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

        /////////////////StatuerPlacering end//////////////////
        ///

        /// 
        ///       /////////////////StatueBehandling//////////////////

        public async Task<List<StatueBehandling>> GetStatueBehandlingList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/statueBehandlings";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatueBehandlingList = await response.Content.ReadAsAsync<List<StatueBehandling>>();
                        return StatueBehandlingList;
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

        public async Task<StatueBehandling> GetStatueBehandling(StatueBehandling getStatueBehandling)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/StatueBehandlings/" + getStatueBehandling.StatueBehandling_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var StatueBehandling = await response.Content.ReadAsAsync<StatueBehandling>();
                        return StatueBehandling;
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

        public async Task<StatueBehandling> PostStatueBehandling(StatueBehandling newStatueBehandling)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<StatueBehandling>("API/StatueBehandlings/", newStatueBehandling);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newStatueBehandling;
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
        public async Task<StatueBehandling> PutStatueBehandling(StatueBehandling udStatueBehandling)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<StatueBehandling>("API/StatueBehandlings/" + udStatueBehandling.StatueBehandling_id, udStatueBehandling);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udStatueBehandling;
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

        public async Task<StatueBehandling> DeleteStatueBehandling(StatueBehandling delStatueBehandling)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/StatueBehandlings/" + delStatueBehandling.StatueBehandling_id;

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

        /////////////////StatueBehandling end//////////////////
        ///
        /// 
        ///       /////////////////SkadeTyper//////////////////

        public async Task<List<SkadeTyper>> GetSkadeTyperList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/SkadeTypers";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var SkadeTyperList = await response.Content.ReadAsAsync<List<SkadeTyper>>();
                        return SkadeTyperList;
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

        public async Task<SkadeTyper> GetSkadeTyper(SkadeTyper getSkadeTyper)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/SkadeTypers/" + getSkadeTyper.SkadeType_Id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var SkadeTyper = await response.Content.ReadAsAsync<SkadeTyper>();
                        return SkadeTyper;
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

        public async Task<SkadeTyper> PostSkadeTyper(SkadeTyper newSkadeTyper)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<SkadeTyper>("API/SkadeTypers/", newSkadeTyper);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newSkadeTyper;
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
        public async Task<SkadeTyper> PutSkadeTyper(SkadeTyper udSkadeTyper)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<SkadeTyper>("API/SkadeTypers/" + udSkadeTyper.SkadeType_Id, udSkadeTyper);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udSkadeTyper;
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

        public async Task<SkadeTyper> DeleteSkadeTyper(SkadeTyper delSkadeTyper)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/SkadeTypers/" + delSkadeTyper.SkadeType_Id;

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

        /////////////////SkadeTyper end//////////////////
        ///    /// 
        ///       /////////////////Behandlingstyper//////////////////

        public async Task<List<Behandlingstyper>> GetBehandlingstyperList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Behandlingstypers";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var BehandlingstyperList = await response.Content.ReadAsAsync<List<Behandlingstyper>>();
                        return BehandlingstyperList;
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

        public async Task<Behandlingstyper> GetBehandlingstyper(Behandlingstyper getBehandlingstyper)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Behandlingstypers/" + getBehandlingstyper.Behandlingstype_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Behandlingstyper = await response.Content.ReadAsAsync<Behandlingstyper>();
                        return Behandlingstyper;
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

        public async Task<Behandlingstyper> PostBehandlingstyper(Behandlingstyper newBehandlingstyper)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<Behandlingstyper>("API/Behandlingstypers/", newBehandlingstyper);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newBehandlingstyper;
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
        public async Task<Behandlingstyper> PutBehandlingstyper(Behandlingstyper udBehandlingstyper)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Behandlingstyper>("API/Behandlingstypers/" + udBehandlingstyper.Behandlingstype_id, udBehandlingstyper);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udBehandlingstyper;
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

        public async Task<Behandlingstyper> DeleteBehandlingstyper(Behandlingstyper delBehandlingstyper)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Behandlingstypers/" + delBehandlingstyper.Behandlingstype_id;

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

        /////////////////Behandlingstyper end////////////////// 
        /// 
        ///  /// 
        ///       /////////////////Skader//////////////////

        public async Task<List<Skader>> GetSkaderList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Skaders";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var SkaderList = await response.Content.ReadAsAsync<List<Skader>>();
                        return SkaderList;
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

        public async Task<Skader> GetSkader(Skader getSkader)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Skaders/" + getSkader.Skade_id;

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlString).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Skader = await response.Content.ReadAsAsync<Skader>();
                        return Skader;
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

        public async Task<Skader> PostSkader(Skader newSkader)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                //try
                //{
                var response = await client.PostAsJsonAsync<Skader>("API/Skaders/", newSkader);
                if (response.IsSuccessStatusCode)
                {
                    //return MyNewGuest;
                    ErrorMessage = response.StatusCode.ToString();
                    return newSkader;
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
        public async Task<Skader> PutSkader(Skader udSkader)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = await client.PutAsJsonAsync<Skader>("API/Skaders/" + udSkader.Skade_id, udSkader);
                    if (response.IsSuccessStatusCode)
                    {

                        ErrorMessage = response.StatusCode.ToString();
                        return udSkader;
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

        public async Task<Skader> DeleteSkader(Skader delSkader)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                string urlString = "api/Skaders/" + delSkader.Skade_id;

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

        /////////////////Skader end////////////////// 
    }
}

