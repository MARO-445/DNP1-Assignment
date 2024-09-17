using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository)
{
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Manage posts selected");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create new post");
            Console.WriteLine("2 - View posts");
            Console.WriteLine("-1 - Exit");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
        
            if (input == "1")
            {
                // Create new post
                CreatePostView createPostView = new CreatePostView(postRepository);
                await createPostView.StartAsync();
            }
            else if (input == "2")
            {
                // View posts
                ListPostsView listPostsView = new ListPostsView(postRepository, commentRepository);
                await listPostsView.StartAsync();
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