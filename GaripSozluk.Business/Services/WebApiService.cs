using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class WebApiService : IWebApiService
    {
        public ApiSearchViewModel SearchFromApi(ApiSearchViewModel model)
        {
            var searchRow = new ApiSearchViewModel();
            var client = new RestClient();
            if (model.SearchType == 1)
            {
                client = new RestClient($"http://openlibrary.org/search.json?author=" + model.Text);
            }
            else
            {
                client = new RestClient($"http://openlibrary.org/search.json?title=" + model.Text);
            }
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiSearchViewModel>(response.Content);
                content.docs = content.docs.OrderByDescending(x => x.first_publish_year).ToList();
                return content;
            }

            return searchRow;
        }

        public ApiSearchViewModel SearchFromApiInHeader(string title)
        {
            var searchRow = new ApiSearchViewModel();
            var client = new RestClient();
            if (title.EndsWith("(Kitap)"))
            {
                title = title.Remove(title.Length-7);
                client = new RestClient($"http://openlibrary.org/search.json?title=" + title);
            }
            else
            {
                title = title.Remove(title.Length - 7);
                client = new RestClient($"http://openlibrary.org/search.json?author=" + title);
            }
            var request = new RestRequest(Method.GET);
             IRestResponse response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiSearchViewModel>(response.Content);
                content.docs = content.docs.OrderByDescending(x => x.first_publish_year).Take(5).ToList();
                return content;
            }

            return searchRow;
        }
    }
}
