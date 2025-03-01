using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;

public class PlayerService(HttpClient httpClient, IConfiguration configuration)
{
  private readonly HttpClient _httpClient = httpClient;
  private readonly IConfiguration _configuration = configuration;

    public async Task<List<PlayersDto>> GetPlayers(string token)
  {
    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    var result = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}players");
    string responseBody = await result.Content.ReadAsStringAsync();

    return JsonConvert.DeserializeObject<List<PlayersDto>>(responseBody);
  }
}