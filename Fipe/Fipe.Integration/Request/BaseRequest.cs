using Fipe.Integration.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fipe.Integration.Request
{
    public class BaseRequest : IRequest
    {
        private HttpClient _client;

        public BaseRequest()
        {
            _client = new HttpClient();
        }

        public virtual async Task<T> GetRequestAsync<T>(string baseUrl, string url) where T : class
        {
            try
            {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.GetAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                } 
                else
                {
                    throw new Exception("Erro ao processar a requisição.");
                }
            } 
            catch(Exception)
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> GetRequestListAsync<T>(string baseUrl, string url) where T : class
        {
            try
            {
                _client.BaseAddress = new Uri(baseUrl);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception("Erro ao processar a requisição.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
