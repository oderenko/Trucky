using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trucky.Interfaces {
  public interface IBaseRepository<T> {
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task Create(T item);
    Task Update(T item);
    Task Delete(int id);
  }
}
