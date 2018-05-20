using System.Collections.Generic;
using Trucky.Models.DB;

namespace Trucky.Interfaces {
  public interface ILookupRepository {
    IEnumerable<LkupCustomerType> GetCustomerTypes();
    IEnumerable<LkupPosition> GetPositions();
  }
}
