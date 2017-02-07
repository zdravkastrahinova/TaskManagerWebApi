using System.Collections.Generic;
using System.Linq;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Services
{
    public class UsersService : BaseService<User>
    {
        public UsersService (): base() { }

        public bool IfUserExists(User model)
        {
            User user = new UsersRepository().GetAll().FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Task> GetByUserID(int userID)
        {
            return new TasksRepository().GetAll().Where(t => t.UserID == userID);
        }
    }
}