using CHUACSystem.Data.Models;
using CHUACSystem.Service.ViewModels;

namespace CHUACSystem.Service.Interfaces
{
    public interface IUserService: IGenericService<User, UserView, UserBase>
    {
        UserView SignIn(string account, string password);
    }
}
