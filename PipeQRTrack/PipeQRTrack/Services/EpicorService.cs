using Newtonsoft.Json.Linq;
using PipeQRTrack.Data;

namespace PipeQRTrack.Services
{
    public class EpicorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://ausmtsapp01.epicorsaas.com/saas205/api/v1/BaqSvc/WN_PipeCust_01";
        private readonly string _authHeader = "Basic MTkzMzAtU1NVU0FJTlRFR1JBVElPTjpBe214aHhXRCgocWh9VitNd0FYPg==";
        private readonly string _apiKeyHeader = "kTWSw9mI1R7rf3J8xf7heTWe8H0JVfSuwtp7a13VfJPVR";

        public EpicorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Authorization", _authHeader);
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKeyHeader);
        }

        public async Task<(List<EpicorJobInfo> JobInfos, string Message)> GetJobInfosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(jsonResponse);

                    if (jsonObject["value"] is JArray jsonArray)
                    {
                        var jobInfos = jsonArray.ToObject<List<EpicorJobInfo>>();
                        return (jobInfos, $"Successfully retrieved {jobInfos.Count} job infos.");
                    }
                    else
                    {
                        return (new List<EpicorJobInfo>(), "Error: 'value' property not found or not an array.");
                    }
                }
                else
                {
                    return (new List<EpicorJobInfo>(), $"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                return (new List<EpicorJobInfo>(), $"Exception: {ex.Message}");
            }
        }


        public async Task<(EpicorJobInfo JobInfo, string Message)> GetJobInfoByLotNumberAsync(string lotNumber)
        {
            try
            {
                var (jobInfos, message) = await GetJobInfosAsync();

                if (!message.StartsWith("Successfully"))
                {
                    return (null, message);
                }

                var matchingJobInfo = jobInfos.FirstOrDefault(j => j.LotNumber == lotNumber);

                if (matchingJobInfo != null)
                {
                    return (matchingJobInfo, $"Successfully found job info for lot number {lotNumber}.");
                }
                else
                {
                    return (null, $"No job info found for lot number {lotNumber}.");
                }
            }
            catch (Exception ex)
            {
                return (null, $"An error occurred while searching for lot number {lotNumber}: {ex.Message}");
            }
        }

    }
}
