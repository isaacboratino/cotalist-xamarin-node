using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppCotacao.Data.ServicesRestfull
{
    public abstract class BaseRestService<T> : IRestService<T> where T : class
    {
        protected string urlApi;
        protected string apiMap;
        protected HttpClient client;        

        public void ChangeaApiMap(string apiMap)
        {
            this.apiMap = apiMap;
            this.urlApi = string.Format("{0}/{1}/", App.BASE_API_URL, apiMap) + "{0}";
        }

        public BaseRestService(string apiMap)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(App.BASE_API_URL);
            client.MaxResponseContentBufferSize = 256000;

            this.ChangeaApiMap(apiMap);
        }

        public BaseRestService(string token, string apiMap)
        {
            //var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.BaseAddress = new Uri(App.BASE_API_URL);
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            this.ChangeaApiMap(apiMap);
        }

        public async Task<ObjectReturnRestService<T>> RefreshDataAsync()
        {            
            ObjectReturnRestService<T> retorno = new ObjectReturnRestService<T>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems
            var uri = new Uri(string.Format(urlApi, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                retorno.HttpStatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    retorno.IsSuccess = true;
                    retorno.ContentList = JsonConvert.DeserializeObject<List<T>>(content);
                }
                else
                {
                    retorno.IsSuccess = false;
                    retorno.ErrorMessage = response.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno.IsSuccess = false;
                retorno.HasError = true;
                retorno.ErrorMessage = ex.Message;
            }

            return retorno;
        }

        public async Task<ObjectReturnRestService<T>> SaveAsync(T item, bool isNewItem)
        {
            ObjectReturnRestService<T> retorno = new ObjectReturnRestService<T>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems
            var uri = new Uri(string.Format(urlApi, string.Empty));            

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                retorno.HttpStatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    retorno.IsSuccess = true;
                    retorno.SuccessMessage = "Item salvo com sucesso";
                } 
                else
                {
                    retorno.IsSuccess = false;
                    retorno.ErrorMessage = response.Content.ToString();
                }

            }
            catch (Exception ex)
            {
                retorno.IsSuccess = false;
                retorno.HasError = true;
                retorno.ErrorMessage = ex.Message;
            }

            return retorno;
        }

        async Task<ObjectReturnRestService<T>> IRestService<T>.GenericSend(Dictionary<string, string> payload)
        {
            ObjectReturnRestService<T> retorno = new ObjectReturnRestService<T>();            

            try
            {
                // RestUrl = http://developer.xamarin.com:8081/api/todoitems
                var uri = new Uri(string.Format(urlApi, string.Empty));
                using (var req = new HttpRequestMessage(HttpMethod.Post, apiMap) { Content = new FormUrlEncodedContent(payload) })
                {
                    using (var response = await client.SendAsync(req).ConfigureAwait(false))
                    {
                        retorno.HttpStatusCode = response.StatusCode;

                        string content = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            retorno.IsSuccess = true;
                            retorno.JSonContent = JsonConvert.DeserializeObject<JObject>(content);
                            retorno.SimpleContent = (string)retorno.JSonContent["token"];
                        }
                        else
                        {
                            retorno.IsSuccess = false;
                            retorno.JSonContent = JsonConvert.DeserializeObject<JObject>(content);
                            retorno.ErrorMessage = (string)retorno.JSonContent["msg"];
                        }
                    }                        
                }                    
            }
            catch (Exception ex)
            {
                retorno.IsSuccess = false;
                retorno.HasError = true;
                retorno.ErrorMessage = ex.Message;
            }

            return retorno;
        }

        public async Task<ObjectReturnRestService<T>> DeleteAsync(string id)
        {
            ObjectReturnRestService<T> retorno = new ObjectReturnRestService<T>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems/{0}
            var uri = new Uri(string.Format(urlApi, id));

            try
            {
                var response = await client.DeleteAsync(uri);
                retorno.HttpStatusCode = response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    retorno.IsSuccess = true;
                    retorno.SuccessMessage = "Item deletado com sucesso";
                }
                else
                {
                    retorno.IsSuccess = false;
                    retorno.ErrorMessage = response.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno.IsSuccess = false;
                retorno.HasError = true;
                retorno.ErrorMessage = ex.Message;
            }

            return retorno;
        }
    }
}
