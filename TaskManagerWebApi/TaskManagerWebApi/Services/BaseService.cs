using System.Collections.Generic;
using TaskManagerWebApi.Models;
using TaskManagerWebApi.Repositories;

namespace TaskManagerWebApi.Services
{
    public class BaseService<T> where T : BaseModel, new()
    {
        private readonly BaseRepository<T> baseRepo;

        public BaseService()
        {
            this.baseRepo = new BaseRepository<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.baseRepo.GetAll();
        }

        public T GetByID(int id)
        {
            return this.baseRepo.GetByID(id);
        }

        public void Save(T item)
        {
            this.baseRepo.Save(item);
        }

        public void Delete(int id)
        {
            this.baseRepo.Delete(id);
        }
    }
}