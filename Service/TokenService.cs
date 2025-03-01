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
      var data = new {
        email = "j.doe3@mail.com",
        password = "123456"
      };

      var result = await _httpClient.PostAsJsonAsync("http://127.0.0.1:5025/api/access/login", data);
      string responseBody = await result.Content.ReadAsStringAsync();
      Console.WriteLine($"Response: {JsonConvert.DeserializeObject<TokenDto>(responseBody)}");

      return JsonConvert.DeserializeObject<TokenDto>(responseBody);
    }
  }