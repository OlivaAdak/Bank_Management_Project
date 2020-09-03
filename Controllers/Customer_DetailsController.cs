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
        readonly log4net.ILog _log4net;

        private readonly BankDBContext _con;

        public Customer_DetailsController(BankDBContext con)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(Customer_DetailsController));
            _con = con;
        }

        // GET: api/<CustDetailsController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            _log4net.Info(" Http GET request For Customer Details");
            return _con.Customers.ToList();
        }

        // GET api/<CustDetailsController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            _log4net.Info(" Http GET_BY_ID request For Customer Details");
            Customer c = _con.Customers.Find(id);
            return c;
        }

        // POST api/<CustDetailsController>
        [HttpPost]
        public void Post(Customer customer)
        {
            _log4net.Info(" Http POST request For Customer Details");
            _con.Customers.Add(customer);
            _con.SaveChanges();
        }

        // PUT api/<CustDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            _log4net.Info(" Http PUT request For Customer Details");
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
            _log4net.Info(" Http DELETE request For Customer Details");
            _con.Customers.Remove(_con.Customers.Find(id));
            _con.SaveChanges();
        }
    }
}
