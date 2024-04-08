using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebYoga.IRepository;
using WebYoga.Model;

namespace WebYoga.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected WebYogaDBContext db { get; set; }
        protected DbSet<T> table = null;

        //Phương thức khởi tạo 
        public GenericRepository()
        {
            db = new WebYogaDBContext();
            table = db.Set<T>();
        }
        public GenericRepository(WebYogaDBContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(int id)
        {
            return table.Find(id);
        }
        public int Update(T item)
        {
            table.Attach(item);
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int Create(T item)
        {
            table.Add(item);
            return db.SaveChanges();
        }
        public int Delete(int id)
        {
            T t = table.Find(id);
            table.Remove(t);
            return db.SaveChanges();
        }
    }
}
