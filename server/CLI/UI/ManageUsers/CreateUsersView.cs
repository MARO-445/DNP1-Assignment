using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUsersView(IUserRepository userRepository)
{
    private async Task AddUserAsync(string name, string password)
    {
        User add = new User(name, password);
        User created = await userRepository.AddAsync(add);
    }
    
    public async Task StartAsync()
    {
        var ready = false;
        while (!ready)
        {
            CliApp.ChatReset();
            Console.WriteLine("Create new user selected");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create new user");
            Console.WriteLine("-1 - go back");
            Console.WriteLine("Type now:");
            var input = Console.ReadLine();
        
            if (input == "1")
            {
                // Create new user
                Console.WriteLine("Set name:");
                var name = Console.ReadLine();
                Console.WriteLine("Set name:");
                var password = Console.ReadLine();

                if (name != null && password != null)
                {
                    Console.WriteLine("User created with name: " + name + ", password: " + password);
                    await AddUserAsync(name, password);
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