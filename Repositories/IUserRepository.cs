using TodoApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.Repositories
{
    public interface IUserRepository 
    {
        Task<IEnumerable<User>> Get();

        Task<User> Get(long Id);

        Task<User> Create(User user);

        Task Update(User user);

        Task Delete(long Id);
    }
}
