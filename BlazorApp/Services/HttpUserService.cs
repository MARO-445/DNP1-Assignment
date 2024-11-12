using System.Net.Http.Json;

public class HttpUserService : IUserService
{
    private readonly HttpClient client;

    public HttpUserService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<UserDto> AddUserAsync(CreateUserDto request)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("users", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto request)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync($"users/{id}", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        return await client.GetFromJsonAsync<UserDto>($"users/{id}");
    }
}