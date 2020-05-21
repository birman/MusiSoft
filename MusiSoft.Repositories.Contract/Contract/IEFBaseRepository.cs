using System.Collections.Generic;

namespace MusiSoft.Repositories.Contract.Contract
{
    public interface IEFBaseRepository
    {
        void SaveChanges();

        void Add<T>(T item, bool saveChanges) where T : class;

        void Edit<T>(T item, bool saveChanges) where T : class;

        void Delete<T>(T item, bool saveChanges) where T : class;

        void AddList<T>(List<T> items, bool saveChanges) where T : class;

        void EditList<T>(List<T> items, bool saveChanges) where T : class;

        void DeleteList<T>(List<T> item, bool saveChanges) where T : class;

        void ExecuteSqlCommand(string command, bool saveChanges);

        void SetEntityState<T>(T Entity) where T : class;

        void Attach<T>(T Entity) where T : class;

        void Detach<T>(T item) where T : class;

        bool Exists<T>(T entity) where T : class;

        IEnumerable<T> FindAll<T>() where T : class;
    }
}