using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView(
    IUserRepository userRepository,
    ICommentRepository commentRepository,
    IPostRepository postRepository)
{

    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("User management selected");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create new user");
            Console.WriteLine("2 - Users overview");
            Console.WriteLine("-1 - go back");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
        
            if (input == "1")
            {
                // Create new user
                CreateUsersView createUsersView = new CreateUsersView(userRepository);
                await createUsersView.StartAsync();
            }
            else if (input == "2")
            {
                // Posts overview
                ListUsersView listUsersView = new ListUsersView(userRepository);
                await listUsersView.StartAsync();
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