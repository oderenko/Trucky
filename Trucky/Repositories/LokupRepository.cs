using System;
using System.Collections.Generic;
using System.Linq;
using Trucky.Interfaces;
using Trucky.Models.DB;

namespace Trucky.Repositories {
  public class LokupRepository : ILookupRepository {
    private readonly TruckyContext _context;

    public LokupRepository(TruckyContext context) {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<LkupCustomerType> GetCustomerTypes() {
      return  _context.LkupCustomerTypes.ToList();
    }

    public IEnumerable<LkupPosition> GetPositions() {
      return _context.LkupPositions.ToList();
    }
  }
}
