using Blazor.Dto;
using Newtonsoft.Json;

namespace Blazor.Service;
  public class TokenService
  {
    private readonly HttpClient _httpClient;

    public TokenService()
    {
      _httpClient = new HttpClient();
    }

    public async Task<TokenDto> GetToken()
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
      IConfiguration configuration = builder.Build();

      var data = new {
        email = configuration["ApiMail"],
        password = configuration["ApiPassword"]
      };

      var result = await _httpClient.PostAsJsonAsync($"{configuration["ApiUrl"]}access/login", data);
      string responseBody = await result.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<TokenDto>(responseBody);
    }
  }