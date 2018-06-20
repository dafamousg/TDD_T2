using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDD_T2.Models
{
    public interface IApiRequest<T>
    {
        IEnumerable<T> GetAllData();

        void AddEntity(T entity);

        void ModifyEntity(int id, T entity);

        void DeleteEntity(T entity);
    }
}
