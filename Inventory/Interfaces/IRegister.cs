global using Inventory.DTOs;

namespace Inventory.Interfaces
{
    public interface IRegister
    {
        Task<ResponseDetail<User>> RegisterAsync(UserRegisterDTO model);
    }
}
