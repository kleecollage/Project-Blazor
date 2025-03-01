using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;

public class PlayerPhotoService(HttpClient httpClient, IConfiguration configuration)
{
  private readonly HttpClient _httpClient = httpClient;
  private readonly IConfiguration _configuration = configuration;

  public async Task<List<PlayersPhotoDto>> GetPlayersPhoto(string token, int id)
  {
    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    var result = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}players-photos/{id}");
    string responseBody = await result.Content.ReadAsStringAsync();

    return JsonConvert.DeserializeObject<List<PlayersPhotoDto>>(responseBody);
  }
}