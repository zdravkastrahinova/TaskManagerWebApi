using System.Linq;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository() : base() { }

        public bool IfUserExists(User model)
        {
            User user = new UsersRepository().GetAll().FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}