using System.Collections.Generic;
using System.Threading.Tasks;
using Trucky.Models.DB;

namespace Trucky.Interfaces {
  public interface ITruckyService {
    IEnumerable<LkupCustomerType> GetCustomerTypes();
    IEnumerable<LkupPosition> GetPositions();

    Task<IEnumerable<Customer>> GetAllCustomers();
    Task CreateCustomer(Customer item);
    Task UpdateCustomer(Customer item);
    Task DeleteCustomer(int id);
    Task<Customer> GetCustomer(int id);

    // Task<IEnumerable<Employee>> GetAllEmployees();
    // Task CreateEmployee(Employee item);
    // Task UpdateEmployee(Employee item);
    // Task DeleteEmployee(int id);
    // Task<Employee> GetEmployee(int id);
    // 
    // Task<IEnumerable<Transportation>> GetAllTransportations();
    // Task CreateTransportation(Transportation item);
    // Task UpdateTransportation(Transportation item);
    // Task DeleteTransportation(int id);
    // Task<Transportation> GetTransportation(int id);
    // 
    // Task<IEnumerable<Invoice>> GetAllInvoices();
    // Task CreateInvoice(Invoice item);
    // Task UpdateInvoice(Invoice item);
    // Task DeleteInvoice(int id);
    // Task<Invoice> GetInvoice(int id);
  }
}
