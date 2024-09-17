using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp()
{
    private readonly IPostRepository postRepository;
    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;

    public CliApp(IUserRepository userRepository, ICommentRepository commentRepository, IPostRepository postRepository) : this()
    {
        this.postRepository = postRepository;
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
    }

    public async Task StartAsync()
    {
        while (true)
        {
            CliApp.ChatReset();
            Console.WriteLine("Welcome to the system!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Manage users");
            Console.WriteLine("2 - Manage posts");
            Console.WriteLine("-1 - Exit");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
        
            if (input == "1")
            {
                // Manage users
                ManageUsersView manageUsersView = new ManageUsersView(userRepository, commentRepository, postRepository);
                await manageUsersView.StartAsync();
            }
            else if (input == "2")
            {
                // Manage posts
                ManagePostsView managePostsView = new ManagePostsView(userRepository, commentRepository, postRepository);
                await managePostsView.StartAsync();
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

    public static void ChatReset()
    {
        Console.Clear();
        Console.Beep();
        Console.WriteLine("________________________");
    }
}