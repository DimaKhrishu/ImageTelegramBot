using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConvertApiDotNet;

namespace TgBot.Clients
{
    class ImageClient
    {
        private HttpClient _client;
        private static string _adress;
        public ImageClient()
        {
            _adress = Constants.adress;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }
        public async Task<Stream> RemoveBackground(string url)
        {
            var responce = await _client.GetAsync($"/imagehelperbot/removebg/?image_url={url}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStreamAsync().Result;
            return content;
        }
        public async Task<String> ConvertToPdf(string url)
        {
            
            var responce = await _client.GetAsync($"/imagehelperbot/convertpdf/?File={url}");
            var result = responce.Content.ReadAsStringAsync().Result;
            return result;
        }
        //public async Task<String> GetTgImage(string id)
        //{

        //    var responce = await _client.GetAsync($"/imagehelperbot/getTgImage/?Id={id}");
        //    var result = responce.Content.ReadAsStringAsync().Result;
        //    return result;
        //}
    }
}
