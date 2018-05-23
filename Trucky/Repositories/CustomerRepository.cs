using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trucky.Interfaces;
using Trucky.Models.DB;
using Trucky.Models.ViewModels;

namespace Trucky.Repositories {
  public class CustomerRepository : ICustomerRepository {
    private readonly TruckyContext _context;

    public CustomerRepository(TruckyContext context) {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Customer item) {
      _context.Add(item);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id) {
      var customer = await _context.Customers
        .SingleOrDefaultAsync(m => m.CustomerId == id);
      _context.Customers.Remove(customer);
      await _context.SaveChangesAsync();
    }

    public async Task<Customer> Get(int id) {
      return await _context.Customers
          .Include(c => c.CustomerType)
          .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Customer>> GetAll() {
      return await _context.Customers.AsNoTracking()
        .Include(c => c.CustomerType)
        .ToListAsync();
    }

    public async Task Update(Customer item) {
      try {
        _context.Update(item);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException ex) {
        if (!CustomerExists(item.CustomerId)) {
          throw new DllNotFoundException();
        }
        else {
          throw;
        }
      }
    }

    private bool CustomerExists(int id) {
      return _context.Customers.Any(e => e.CustomerId == id);
    }
  }
}
