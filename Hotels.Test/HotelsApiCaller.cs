using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hotels.Test
{
    class HotelsApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:52836/api");
        public static List<Hotel> AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            client.Execute(request);
            var getRequest = new RestRequest("Hotel", Method.GET);
            IRestResponse response = client.Execute(getRequest);
            dynamic data = JObject.Parse(response.Content);
            data = data.hotelsResponse;
            var content = Convert.ToString(data);
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static List<Hotel> GetHotels()
        {
            var getRequest = new RestRequest("Hotel", Method.GET);
            IRestResponse response = client.Execute(getRequest);
            dynamic data = JObject.Parse(response.Content);
            data = data.hotelsResponse;
            var content = Convert.ToString(data);
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

    }
}
