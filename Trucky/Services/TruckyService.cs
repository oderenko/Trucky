using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trucky.Interfaces;
using Trucky.Models.DB;
using Trucky.Models.ViewModels;

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

    //public TruckyService(ICustomerRepository customerRepository, IEmployeeRepository employeeRepository,
    //  ITransportationRepository transportationRepository, IInvoicesRepository invoiceRepository,
    //  ILookupRepository lookupRepository) {
    public TruckyService(ICustomerRepository customerRepository, ILookupRepository lookupRepository) {
      _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
      //_employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
      //_transportationRepository = transportationRepository ?? throw new ArgumentNullException(nameof(transportationRepository));
      //_invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
      _lookupRepository = lookupRepository ?? throw new ArgumentNullException(nameof(lookupRepository));
    }

    #endregion

    #region customer methods

    public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers() {
      return (await _customerRepository.GetAll())
        .Select(a => ModelToView(a))
        .ToList();
    }

    public async Task CreateCustomer(CustomerViewModel item) {
      var customer = ViewToModel(item);
      await _customerRepository.Create(customer);
    }

    public async Task UpdateCustomer(CustomerViewModel item) {
      var customer = ViewToModel(item);
      await _customerRepository.Update(customer);
    }

    public async Task DeleteCustomer(int id) {
      await _customerRepository.Delete(id);
    }

    public async Task<CustomerViewModel> GetCustomer(int id) {
      var customer = (await _customerRepository.Get(id));
      return ModelToView(customer);
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

    private string DefineIfIsCorporate(bool? isCorporate) {
      if (!isCorporate.HasValue) {
        return "no";
      }
      else {
        return isCorporate.Value ? "yes" : "no";
      }
    }

    private CustomerViewModel ModelToView(Customer cust) {
      var custTypes = _lookupRepository.GetCustomerTypes();

      return new CustomerViewModel() {
        CustomerId = cust.CustomerId,
        CustomerType = cust.CustomerType.Type,
        CustomerTypeFid = cust.CustomerTypeFid,
        CystomreTypes = custTypes,
        Email = cust.Email,
        FullName = cust.FullName,
        IsCorporate = DefineIfIsCorporate(cust.IsCorporate),
        PhoneNumber = cust.PhoneNumber
      };
    }

    public bool DefineIfIsCorporate(string isCorporate) {
      return (isCorporate == "yes") ? true : false;
    }

    private Customer ViewToModel(CustomerViewModel view) {
      return new Customer() {
        CustomerId = view.CustomerId,
        CustomerTypeFid = view.CustomerTypeFid,
        Email = view.Email,
        FullName = view.FullName,
        IsCorporate = DefineIfIsCorporate(view.IsCorporate),
        PhoneNumber = view.PhoneNumber
      };
    }
  }
}