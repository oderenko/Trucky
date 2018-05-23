using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trucky.Interfaces;
using Trucky.Models.ViewModels;

namespace Trucky.Controllers {
  public class CustomersController : Controller {
    private readonly ITruckyService _truckyService;

    public CustomersController(ITruckyService truckyService) {
      _truckyService = truckyService ?? throw new ArgumentNullException(nameof(truckyService));
    }

    [HttpGet]
    public async Task<IActionResult> Index() {
      var customers = await  _truckyService.GetAllCustomers();
      return View(customers);
    }

    // GET: Customers/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return BadRequest(ModelState);
      }

      var customer = await _truckyService.GetCustomer(id.Value);

      if (customer == null) {
        return NotFound();
      }

      return View(customer);
    }

    // GET: Customers/Create
    public IActionResult Create() {
      var customerTypes = _truckyService.GetCustomerTypes();
      ViewData["CustomerTypeFid"] = new SelectList(customerTypes, "LkupCustomerTypeId", "LkupCustomerTypeId");
      return View();
    }

    // POST: Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CustomerId,FullName,PhoneNumber,Email,IsCorporate,CustomerTypeFid, CustomerType")] CustomerViewModel customer) {
      if (ModelState.IsValid) {
        await _truckyService.CreateCustomer(customer);
        return RedirectToAction(nameof(Index));
      }

      var customerTypes = _truckyService.GetCustomerTypes();
      ViewData["CustomerTypeFid"] = new SelectList(customerTypes, "LkupCustomerTypeId", "LkupCustomerTypeId", customer.CustomerTypeFid);
      return View(customer);
    }

    // GET: Customers/Edit/5
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return BadRequest();
      }

      var customer = await _truckyService.GetCustomer(id.Value);
      if (customer == null) {
        return NotFound();
      }

      var customerTypes = _truckyService.GetCustomerTypes();
      ViewData["CustomerTypeFid"] = new SelectList(customerTypes, "LkupCustomerTypeId", "LkupCustomerTypeId", customer.CustomerTypeFid);
      return View(customer);
    }

    // POST: Customers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FullName,PhoneNumber,Email,IsCorporate,CustomerTypeFid, CustomerType")] CustomerViewModel customer) {
      if (id != customer.CustomerId) {
        return BadRequest();
      }

      if (ModelState.IsValid) {
        try {
          await  _truckyService.UpdateCustomer(customer);
          return RedirectToAction(nameof(Index));
        }catch(DllNotFoundException ex) {
          return NotFound();
        }
      }

      var customerTypes = _truckyService.GetCustomerTypes();
      ViewData["CustomerTypeFid"] = new SelectList(customerTypes, "LkupCustomerTypeId", "LkupCustomerTypeId", customer.CustomerTypeFid);
      return View(customer);
    }

    // GET: Customers/Delete/5
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return BadRequest(ModelState);
      }

      var customer = await _truckyService.GetCustomer(id.Value);
      if (customer == null) {
        return NotFound();
      }

      return View(customer);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      await _truckyService.DeleteCustomer(id);
      return RedirectToAction(nameof(Index));
    }
  }
}
