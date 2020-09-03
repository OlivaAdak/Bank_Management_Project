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
       readonly log4net.ILog _log4net;
        private readonly BankDBContext _con1;
        public Branch_DetailsController(BankDBContext con1)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(Branch_DetailsController));
            _con1 = con1;
        }
        // GET: api/<BranchController>
        [HttpGet]
        public IEnumerable<BranchDetails> Get()
        {
            _log4net.Info("Http GET Request For Branch Details");
            return _con1.Branches.ToList();
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public BranchDetails Get(int id)
        {
            _log4net.Info("Http GET_BY_ID Request For Branch Details");
            BranchDetails bd = _con1.Branches.Find(id);
            return bd;
        }

        // POST api/<BranchController>
        [HttpPost]
        public void Post(BranchDetails details)
        {
            _log4net.Info("Http POST Request For Branch Details");
            _con1.Branches.Add(details);
            _con1.SaveChanges();
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BranchDetails details)
        {
            _log4net.Info("Http PUT Request For Branch Details");
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
            _log4net.Info("Http DELETE Request For Branch Details");
            _con1.Branches.Remove(_con1.Branches.Find(id));
            _con1.SaveChanges();
        }
    }
}
