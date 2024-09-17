using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ListUsersView(IUserRepository userRepository)
{
    private async Task PrintUsersAsync()
    {
        foreach (User user in userRepository.GetMany())
        {
            Console.WriteLine(user.Id + " : " + user.Username + " - " + user.Password);
        }
    }
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Users overview selected");
            await PrintUsersAsync();
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.Read();
            return;
        }
    }
}