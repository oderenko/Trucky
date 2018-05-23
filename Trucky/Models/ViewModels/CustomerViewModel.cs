using System.Collections.Generic;
using Trucky.Models.DB;

namespace Trucky.Models.ViewModels {
  public class CustomerViewModel {
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string IsCorporate { get; set; }

    public int CustomerTypeFid { get; set; }

    public string CustomerType { get; set; }

    public IEnumerable<LkupCustomerType> CystomreTypes { set; get; }
  }
}
