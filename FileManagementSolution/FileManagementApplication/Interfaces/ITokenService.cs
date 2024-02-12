using FileManagementApplication.Models.DTOs;

namespace FileManagementApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);

    }
}
