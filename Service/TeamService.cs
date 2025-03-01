using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;

public class TeamService(HttpClient httpClient, IConfiguration configuration)
{
  private readonly HttpClient _httpClient = httpClient;
  private readonly IConfiguration _configuration = configuration;

    public async Task<List<TeamDto>> GetTeams(string token)
  {
    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
    var result = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}teams");
    string responseBody = await result.Content.ReadAsStringAsync();

    return JsonConvert.DeserializeObject<List<TeamDto>>(responseBody);
  }
}