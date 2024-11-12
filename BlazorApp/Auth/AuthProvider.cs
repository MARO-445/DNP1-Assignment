using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;

    public SimpleAuthProvider(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    private ClaimsPrincipal anonymous => new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(anonymous));
    }

    public async Task Login(string username, string password)
    {
        var response = await httpClient.PostAsJsonAsync("auth/login", new { username, password });
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Login failed");
        }

        var userDto = JsonSerializer.Deserialize<UserDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, userDto.UserName),
            new("UserId", userDto.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, "apiauth");
        var claimsPrincipal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public void Logout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }
}