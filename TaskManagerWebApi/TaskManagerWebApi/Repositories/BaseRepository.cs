using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskManagerWebApi.Models;

namespace TaskManagerWebApi.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        private readonly AppContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            this.context = new AppContext();
            this.dbSet = context.Set<T>();
        }

        public T GetByID(int id)
        {
            return this.dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return this.dbSet.Where(i => !i.IsDeleted).ToList();
        }

        private void Insert(T item)
        {
            this.dbSet.Add(item);
        }

        private void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Save(T item)
        {
            if (item.ID == 0)
            {
                item.DateCreated = DateTime.Now;
                item.DateUpdated = item.DateCreated;
                item.IsDeleted = false;

                Insert(item);
            }
            else
            {
                item.DateUpdated = DateTime.Now;

                Update(item);
            }

            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = GetByID(id);

            if (item != null)
            {
                item.IsDeleted = true;
                item.DateUpdated = DateTime.Now;

                this.context.SaveChanges();
            }
        }
    }
}