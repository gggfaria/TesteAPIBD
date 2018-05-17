using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;

namespace TesteAPIBd.GGGFaria.ServiceAPI.Base
{
    public class CrudAPIService
    {

        protected RestRequest _request;
        protected RestClient _client;
        protected readonly string _urlBase = ConfigurationManager.AppSettings["UrlBase"];

        public List<TEntity> SelectAll<TEntity>(string url)
        {
            _client = new RestClient(_urlBase);
            _request = new RestRequest(url, Method.GET);
            _request.RequestFormat = DataFormat.Json;
            try
            {
                IRestResponse<List<TEntity>> resposta = _client.Execute<List<TEntity>>(_request);
                return JsonConvert.DeserializeObject<List<TEntity>>(resposta.Content);
            }
            catch (System.Exception e)
            {
               return new List<TEntity>();
            }
        }

        public TEntity SelectById<TEntity>(int id, string url)
        {
            _client = new RestClient(_urlBase);
            _request = new RestRequest(url, Method.GET);
            _request.AddParameter("id", id);
            _request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse resposta = _client.Execute(_request);
                return JsonConvert.DeserializeObject<TEntity>(resposta.Content);
            }
            catch (System.Exception e)
            {

                return default(TEntity);
            }
           
        }

    }
}