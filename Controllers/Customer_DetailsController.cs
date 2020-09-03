using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_DetailsController : ControllerBase
    {
        private readonly BankDBContext _con;
        public Customer_DetailsController(BankDBContext con)
        {
            _con = con;
        }
        // GET: api/<CustDetailsController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _con.Customers.ToList();
        }

        // GET api/<CustDetailsController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            Customer c = _con.Customers.Find(id);
            return c;
        }

        // POST api/<CustDetailsController>
        [HttpPost]
        public void Post(Customer customer)
        {
            _con.Customers.Add(customer);
            _con.SaveChanges();
        }

        // PUT api/<CustDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            Customer c = _con.Customers.Find(id);
            c.Name = customer.Name;
            c.Address = customer.Address;
            c.DOB = customer.DOB;
            c.AdharCardNo = customer.AdharCardNo;
            c.PhoneNo = customer.PhoneNo;
            c.Email = customer.Email;
            c.AccountType = customer.AccountType;
            c.Balance = customer.Balance;
            _con.Customers.Update(c);
            _con.SaveChanges();
        }

        // DELETE api/<CustDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _con.Customers.Remove(_con.Customers.Find(id));
            _con.SaveChanges();
        }
    }
}
