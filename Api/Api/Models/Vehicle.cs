using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class Vehicle
    {
        public int id { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string licenceNumber { get; set; }
        public string power { get; set; }
        public string topSpeed { get; set; }
        public string km { get; set; }
        public string torque { get; set; }
        public string co2Emissions { get; set; }
        public string euroEmissionStandard { get; set; }
        public string height  { get; set; }
        public string wheelbase { get; set; }
        public string turningCircle { get; set; }
        public string engineSize { get; set; }
        public string cylinders { get; set; }
        public string valves { get; set; }
        public string fuelType { get; set; }
        public string transmission { get; set; }
        public string gearbox { get; set; }
        public string drivetrain { get; set; }
        public string milesPerTank { get; set; }
        public string length { get; set; }
    }
}
