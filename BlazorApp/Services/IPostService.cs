using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPostService
{
    Task<PostDto> AddPostAsync(CreatePostDto request);
    Task<List<PostDto>> GetPostsAsync();
    Task<PostDto> GetPostByIdAsync(int id);
    Task AddCommentAsync(int postId, CreateCommentDto request);
}