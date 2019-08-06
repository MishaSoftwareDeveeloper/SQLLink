using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        // GET: api/Reports
        [HttpGet]
        public List<Report> Get()
        {
            return DB.reports;
        }

        // GET: api/Reports/5
        [Route("activevehicles")]
        [HttpGet]
        public List<Report> GetActive()
        {
            //A list of most active vehicles in the hour/day/month/year
            List<Report> output = DB.reports.GroupBy(x => x.vehicleId).SelectMany(g => g.Skip(2)).ToList();

            return output;
        }

        // POST: api/Reports
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
