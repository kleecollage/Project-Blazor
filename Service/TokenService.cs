using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;
  public class TokenService(IConfiguration configuration)
{
    private readonly HttpClient _httpClient = new();
    private readonly IConfiguration _configuration = configuration;

    public async Task<TokenDto> GetToken()
    {
      var data = new {
        email = _configuration["ApiMail"],
        password = _configuration["ApiPassword"]
      };

      var result = await _httpClient.PostAsJsonAsync($"{_configuration["ApiUrl"]}access/login", data);
      string responseBody = await result.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<TokenDto>(responseBody);
    }
  }