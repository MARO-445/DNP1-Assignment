using System.Net.Http.Json;
using System.Collections.Generic;

public class HttpPostService : IPostService
{
    private readonly HttpClient client;

    public HttpPostService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("posts", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PostDto>();
    }

    public async Task<List<PostDto>> GetPostsAsync()
    {
        return await client.GetFromJsonAsync<List<PostDto>>("posts");
    }

    public async Task<PostDto> GetPostByIdAsync(int id)
    {
        return await client.GetFromJsonAsync<PostDto>($"posts/{id}");
    }

    public async Task AddCommentAsync(int postId, CreateCommentDto request)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync($"posts/{postId}/comments", request);
        response.EnsureSuccessStatusCode();
    }
}