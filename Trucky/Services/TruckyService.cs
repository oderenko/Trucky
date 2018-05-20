using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trucky.Interfaces;
using Trucky.Models.DB;

namespace Trucky.Services {
  public class TruckyService : ITruckyService {
    #region private properties

    private readonly ICustomerRepository _customerRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITransportationRepository _transportationRepository;
    private readonly IInvoicesRepository _invoiceRepository;
    private readonly ILookupRepository _lookupRepository;

    #endregion

    #region constructor

    public TruckyService(ICustomerRepository customerRepository, IEmployeeRepository employeeRepository,
      ITransportationRepository transportationRepository, IInvoicesRepository invoiceRepository,
      ILookupRepository lookupRepository) {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
      _transportationRepository = transportationRepository ?? throw new ArgumentNullException(nameof(transportationRepository));
      _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
      _lookupRepository = lookupRepository ?? throw new ArgumentNullException(nameof(lookupRepository));
    }

    #endregion

    #region customer methods

    public async Task<IEnumerable<Customer>> GetAllCustomers() {
      return await _customerRepository.GetAll();
    }

    public async Task CreateCustomer(Customer item) {
      await _customerRepository.Create(item);
    }

    public async Task UpdateCustomer(Customer item) {
      await _customerRepository.Update(item);
    }

    public async Task DeleteCustomer(int id) {
      await _customerRepository.Delete(id);
    }

    public async Task<Customer> GetCustomer(int id) {
      return await _customerRepository.Get(id);
    }

    #endregion

    #region lookup methods

    public IEnumerable<LkupCustomerType> GetCustomerTypes() {
      return _lookupRepository.GetCustomerTypes();
    }

    public IEnumerable<LkupPosition> GetPositions() {
      return _lookupRepository.GetPositions();
    }

    #endregion
  }
}