using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView(Post context, ICommentRepository commentRepository)
{
    private async Task PrintInfoAsync()
    {
        Console.WriteLine(context.Title);
        Console.WriteLine(context.Content);
        
        Console.WriteLine("");
        Console.WriteLine("Comments:");
        Console.WriteLine("");
        foreach (Comment comment in commentRepository.GetMany())
        {
            Console.WriteLine(context.Id);
            Console.WriteLine(comment.Location);
            if (comment.Location == context.Id)
            {
                Console.WriteLine(comment.Content);
                Console.WriteLine("añ");
            }
            
        }
    }
    
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Post details selected");
            Console.WriteLine("");
            await PrintInfoAsync();
            Console.WriteLine("1 - Add a comment");
            Console.WriteLine("-1 - go back");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
            
            if (input == "1")
            {
                // Add a comment
                CreateCommentView createCommentView = new CreateCommentView(context, commentRepository);
                await createCommentView.StartAsync();
            }
            else if (input == "-1")
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