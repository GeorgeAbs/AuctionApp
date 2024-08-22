using AuctionApp.Constants;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AuctionApp.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly HttpClient _httpClient;

        private string baseUri = GeneralConstants.SERVER_URL;

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            //ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };

        public RequestProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RequestResult<TResult?>> GetAsync<TResult>(string uri, string? token = null)
        {
            ConfigureHttpClient(token);

            var message = await _httpClient.GetAsync(new Uri($"{baseUri}/{uri}"));


            return await GetResultAsync<TResult>(message);
        }

        public async Task<RequestResult<TResult?>> PostAsync<TSend, TResult>(string uri, TSend sendedObj, string? token = null)
        {
            ConfigureHttpClient(token);

            var content = await CreateHTTPContentAsync(sendedObj);

            var message = await _httpClient.PostAsync(new Uri($"{baseUri}/{uri}"), content);

            return await GetResultAsync<TResult>(message);
        }

        public async Task<RequestResult<TResult?>> PutAsync<TSend, TResult>(string uri, TSend sendedObj, string? token = null)
        {
            ConfigureHttpClient(token);

            var content = await CreateHTTPContentAsync(sendedObj);

            var message = await _httpClient.PutAsync(new Uri($"{baseUri}/{uri}"), content);

            return await GetResultAsync<TResult>(message);
        }

        public async Task<RequestResult<TResult?>> DeleteAsync<TResult>(string uri, string? token = null)
        {
            ConfigureHttpClient(token);

            var message = await _httpClient.DeleteAsync(new Uri($"{baseUri}/{uri}"));

            return await GetResultAsync<TResult>(message);
        }

        private void ConfigureHttpClient(string? token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private async Task<RequestResult<TResult?>> GetResultAsync<TResult>(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                switch (message.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new RequestResult<TResult?>(false, (TResult)(object)null!, (int)message.StatusCode);
                    case System.Net.HttpStatusCode.Conflict:
                        return new RequestResult<TResult?>(false, (TResult)(object)null!, (int)message.StatusCode, await message.Content.ReadFromJsonAsync<List<string>>(options) ?? []);
                }
            }

            if (typeof(TResult) == typeof(string))
            {
                return new(true, (TResult)(object)await message.Content.ReadAsStringAsync(), (int)message.StatusCode);
            }

            TResult? result = await message.Content.ReadFromJsonAsync<TResult>(options);

            return new(true, result, (int)message.StatusCode);
        }

        private async Task<HttpContent> CreateHTTPContentAsync<TSend>(TSend value)
        {
            byte[] bytes;

            if (value is BufferedStream bStream)
            {
                using (var ms = new MemoryStream())
                {
                    await bStream.CopyToAsync(ms);

                    bytes = ms.ToArray();
                }

                var fileContent = new ByteArrayContent(bytes);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                var form = new MultipartFormDataContent
                {
                    { fileContent, "fileContent", "image1" }
                };

                return form;
            }

            if (value is string v) 
            {
                return new StringContent(JsonSerializer.Serialize(new StringBody { StringContent = v }, options), System.Text.Encoding.UTF8, "application/json");
            }

            return new StringContent(JsonSerializer.Serialize(value, options), System.Text.Encoding.UTF8, "application/json");
        }

        private class StringBody
        {
            public string StringContent { get; set; }

            public StringBody() { }
        }
    }
}
