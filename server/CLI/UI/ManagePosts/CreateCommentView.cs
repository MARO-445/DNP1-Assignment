using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreateCommentView(Post context, ICommentRepository commentRepository)
{
    public async Task StartAsync()
    {
        Console.WriteLine("Type content:");
        var content = Console.ReadLine();
        Console.WriteLine("Type userId:");
        var userId = Console.ReadLine();
                    
        if (content != null && userId != null)
        {
            Console.WriteLine("Comment created with content: " + content);
            Comment add = new Comment(content, userId , context.Id);
            Comment created = await commentRepository.AddAsync(add);

        }
        else
        {
            Console.Error.WriteLine("Invalid input, press any key to continue");
            Console.Read();
        }
    }
}