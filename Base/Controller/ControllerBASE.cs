using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class ControllerBASE<TEntity> where TEntity : class, IEntity
    {
        DbHotelEContext dbContext;
        DbSet<TEntity> dbSet;

        public ControllerBASE()
        {
            dbContext = new DbHotelEContext();
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual List<TEntity> Get()
        {
            return  dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            var item= dbSet.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return null;
            }
                
            return item;          
        }

        public virtual int Create(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public virtual int Update(TEntity entity)
        {
            dbSet.Attach(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity.Id;
        }

        public Boolean Delete(int id)
        {
            var itemToRemove =  dbSet.FirstOrDefault(x => x.Id == id);
            if (itemToRemove == null)
            {
                return false;
            }

            dbContext.Remove(itemToRemove);
            dbContext.SaveChanges();

            return true;
        }


    }

}
