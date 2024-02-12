using FileManagementApplication.Models.DTOs;

namespace FileManagementApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Register(UserDTO userDTO);
        UserDTO Login(UserDTO userDTO);
    }
}
