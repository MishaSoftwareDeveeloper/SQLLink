using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Report
    {
        public int vehicleId { get; set; }
        public string requestDate { get; set; }
        public string requestType { get; set; } 
    }
}
