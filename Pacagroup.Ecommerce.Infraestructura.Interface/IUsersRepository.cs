using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infraestructura.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
