using System.Threading.Tasks;

public interface IUserService
{
    Task<UserDto> AddUserAsync(CreateUserDto request);
    Task UpdateUserAsync(int id, UpdateUserDto request);
    Task<UserDto> GetUserByIdAsync(int id);
}