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
    public class Branch_DetailsController : ControllerBase
       
    {
        private readonly BankDBContext _con1;
        public Branch_DetailsController(BankDBContext con1)
        {
            _con1 = con1;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public IEnumerable<BranchDetails> Get()
        {
            return _con1.Branches.ToList();
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public BranchDetails Get(int id)
        {
            BranchDetails bd = _con1.Branches.Find(id);
            return bd;
        }

        // POST api/<BranchController>
        [HttpPost]
        public void Post(BranchDetails details)
        {
            _con1.Branches.Add(details);
            _con1.SaveChanges();
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BranchDetails details)
        {
            BranchDetails bd = _con1.Branches.Find(id);
            bd.Location = details.Location;
            bd.IFSC = details.IFSC;

            _con1.Branches.Update(bd);
            _con1.SaveChanges();
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _con1.Branches.Remove(_con1.Branches.Find(id));
            _con1.SaveChanges();
        }
    }
}
