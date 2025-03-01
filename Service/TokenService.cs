using Blazor.Dto;
using System.Text.Json;

namespace Blazor.Service;
  public class TokenService (HttpClient httpClient)
  {
    private readonly HttpClient _httpClient = httpClient;

    public async Task<TokenDto> GetToken()
    {
      var data = new {
        mail = "j.doe3@mail.com",
        password = "123456"
      };

      var result = await _httpClient.PostAsJsonAsync("http://127.0.0.1:5025/api/access/login", data);

      string responseBody = await result.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<TokenDto>(responseBody);
    }
  }