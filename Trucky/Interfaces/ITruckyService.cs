using System.Collections.Generic;
using System.Threading.Tasks;
using Trucky.Models.DB;
using Trucky.Models.ViewModels;

namespace Trucky.Interfaces {
  public interface ITruckyService {
    IEnumerable<LkupCustomerType> GetCustomerTypes();
    IEnumerable<LkupPosition> GetPositions();

    Task<IEnumerable<CustomerViewModel>> GetAllCustomers();
    Task CreateCustomer(CustomerViewModel item);
    Task UpdateCustomer(CustomerViewModel item);
    Task DeleteCustomer(int id);
    Task<CustomerViewModel> GetCustomer(int id);

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
