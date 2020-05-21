using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Contract.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace MusiSoft.Repositories.Base
{
    public abstract class EFBaseRepository : IEFBaseRepository
    {
        protected MusiSoftBDEntities _context;

        public EFBaseRepository()
        {
        }

        public EFBaseRepository(MusiSoftBDEntities dbContext)
        {
            _context = dbContext;
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add<T>(T item, bool saveChanges) where T : class
        {
            try
            {
                item = SetProperty(item, "CreationDate", DateTime.Now);
                item = SetProperty(item, "ModificationDate", DateTime.Now);
                _context.Set(typeof(T)).Add(item);
                _context.Entry(item).State = EntityState.Added;
                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit<T>(T item, bool saveChanges) where T : class
        {
            try
            {
                item = SetProperty(item, "ModificationDate", DateTime.Now);
                if (!Exists(item)) _context.Set(typeof(T)).Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete<T>(T item, bool saveChanges) where T : class
        {
            try
            {
                _context.Set(typeof(T)).Attach(item);
                _context.Entry(item).State = EntityState.Deleted;
                _context.Set(typeof(T)).Remove(item);

                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddList<T>(List<T> items, bool saveChanges) where T : class
        {
            try
            {
                foreach (T item in items)
                {
                    Add(item, false);
                }
                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditList<T>(List<T> items, bool saveChanges) where T : class
        {
            try
            {
                foreach (T item in items)
                {
                    Edit(item, false);
                }
                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteList<T>(List<T> items, bool saveChanges) where T : class
        {
            try
            {
                foreach (T item in items)
                {
                    Delete(item, false);
                }
                if (saveChanges) SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteSqlCommand(string command, bool saveChanges)
        {
            try
            {
                _context.Database.ExecuteSqlCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetEntityState<T>(T Entity) where T : class
        {
            try
            {
                _context.Entry(Entity).State = EntityState.Unchanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach<T>(T Entity) where T : class
        {
            try
            {
                if (!Exists(Entity)) _context.Set(typeof(T)).Attach(Entity);
                _context.Entry(Entity).State = EntityState.Unchanged;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Detach<T>(T item) where T : class
        {
            try
            {
                _context.Entry(item).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists<T>(T entity) where T : class
        {
            try
            {
                return _context.Set<T>().Local.Any(e => e == entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> FindAll<T>() where T : class
        {
            return _context.Set<T>().AsEnumerable();
        }

        private T SetProperty<T>(T item, string property, object value)
        {
            PropertyInfo prop = item.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(item, value, null);
            }

            return item;
        }
    }
}