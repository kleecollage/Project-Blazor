using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;

public class TeamService
{
  private readonly string _token;
  private readonly HttpClient _httpClient;
  public TeamService(string token)
  {
    _token = token;
    _httpClient = new HttpClient();
  }

  public async Task<List<TeamDto>> GetTeams()
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    IConfiguration configuration = builder.Build();


    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
    var result = await _httpClient.GetAsync($"{configuration["ApiUrl"]}teams");
    string responseBody = await result.Content.ReadAsStringAsync();

    return JsonConvert.DeserializeObject<List<TeamDto>>(responseBody);
  }



}