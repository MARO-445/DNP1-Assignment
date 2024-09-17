using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreatePostView(IPostRepository postRepository)
{
    private async Task AddUserAsync(string title, string content, int userId)
    {
        Post add = new Post(title, content, userId);
        Post created = await postRepository.AddAsync(add);
    }
    
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Create new user selected");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create new post");
            Console.WriteLine("-1 - go back");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
        
            if (input == "1")
            {
                // Create new user
                Console.WriteLine("Set title:");
                var title = Console.ReadLine();
                Console.WriteLine("Set content:");
                var content = Console.ReadLine();
                Console.WriteLine("Set userId:");
                var userId = Int32.Parse(Console.ReadLine());
                    
                    
                if (title != null && content != null && userId != null)
                {
                    Console.WriteLine("Post created with title: " + title + ", content: " + content + ", userId: " + userId);
                    await AddUserAsync(title, content, userId);
                    Console.Error.WriteLine("Press any key to continue");
                    Console.Read();
                }
                else
                {
                    Console.Error.WriteLine("Invalid input, press any key to continue");
                    Console.Read();
                }
                
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