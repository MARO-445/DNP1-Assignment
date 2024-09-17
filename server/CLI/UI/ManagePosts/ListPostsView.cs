using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ListPostsView(IPostRepository postRepository, ICommentRepository commentRepository)
{
    private async Task PrintPostsAsync()
    {
        var i = 0;
        foreach (Post post in postRepository.GetMany())
        {
            i++;
            Console.WriteLine(i + " : " + post.Title + " - " + post.UserId);
        }
    }
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Posts overview selected");
            await PrintPostsAsync();
            Console.WriteLine("");
            Console.WriteLine("post number - see details about the post");
            Console.WriteLine("-1 - go back");
            Console.WriteLine("Type now:");
            var input = Int32.Parse(Console.ReadLine());
            
            if (input == 1)
            {
                // See details about the post
                var post = await postRepository.GetSingleAsync(input);
                SinglePostView singlePostView = new SinglePostView(post, commentRepository);
                await singlePostView.StartAsync();
            }
            else if (input == -1)
            {
                return;
            }
            else
            {
                Console.Error.WriteLine("Invalid input.");
            }
        }
    }
}