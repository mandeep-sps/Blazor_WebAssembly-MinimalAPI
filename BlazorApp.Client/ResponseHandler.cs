using BlazorApp.Shared;
using Newtonsoft.Json;

namespace BlazorApp.Client
{
    public static class ResponseHandler
    {
        public static async Task<ApiResponseModel> GetApiResponse(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<ApiResponseModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
