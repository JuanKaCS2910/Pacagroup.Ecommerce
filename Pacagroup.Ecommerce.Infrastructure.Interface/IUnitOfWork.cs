using System;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable //Permite liberar recursos en memoria.
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; } 
    }
}
