using System;
using System.Collections.Generic;
using System.Linq;
using Trucky.Interfaces;
using Trucky.Models.DB;

namespace Trucky.Repositories {
  public class LookupRepository : ILookupRepository {
    private readonly TruckyContext _context;

    public LookupRepository(TruckyContext context) {
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
