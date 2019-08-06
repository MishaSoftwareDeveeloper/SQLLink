using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        public VehiclesController()
        {
            //generate new data base list of vehicles
            if(DB.data == null) 
                DB.data = new List<Vehicle>();

            if(DB.reports == null)
                DB.reports = new List<Report>();
        }


        private void saveReport(int vehicleId, string requestType)
        {
            Report rep = new Report
            {
                requestDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                requestType = requestType,
                vehicleId = vehicleId
            };
            DB.reports.Add(rep);
        }


        // GET: api/Vehicles
        [HttpGet]
        public List<Vehicle> Get()
        {
            foreach (Vehicle v in DB.data)
            {
                this.saveReport(v.id, "GET");
            }

            return DB.data;
        }

        // GET: api/Vehicles/5
        [HttpGet("{searchValue}", Name = "Get")]
        public List<Vehicle> Get(string searchValue)
        {
            //Filter by any of the vehicle’s properties
            //this is simple example of filter because short time of assignment
            List<Vehicle> output = DB.data.Where(value => searchValue.Contains(value.model) ||
            searchValue.Contains(value.year) ||
            searchValue.Contains(value.licenceNumber) ||
            searchValue.Contains(value.power) ||
            searchValue.Contains(value.topSpeed) ||
            searchValue.Contains(value.km) ||
            searchValue.Contains(value.torque) ||
            searchValue.Contains(value.co2Emissions) ||
            searchValue.Contains(value.euroEmissionStandard) ||
            searchValue.Contains(value.height) ||
            searchValue.Contains(value.wheelbase) ||
            searchValue.Contains(value.turningCircle) ||
            searchValue.Contains(value.engineSize) ||
            searchValue.Contains(value.cylinders) ||
            searchValue.Contains(value.valves) ||
            searchValue.Contains(value.fuelType) ||
            searchValue.Contains(value.transmission) ||
            searchValue.Contains(value.gearbox) ||
            searchValue.Contains(value.drivetrain)
            ).ToList();


            foreach (Vehicle v in output)
            {
                this.saveReport(v.id, "GetByFilter");
            }


            return output;
        }





        // POST: api/Vehicles
        [HttpPost]
        public void Post([FromBody] Vehicle value)
        {
            //Prevent duplicate vehicles from being entered 
            //insert to DB data by new licence number
            Vehicle veh = DB.data.FirstOrDefault(d => d.licenceNumber == value.licenceNumber);

            if (veh == null)
            {

                //set id increment 
                if (DB.data.Count < 1)
                    value.id = 1;
                else
                {
                    //last vehicle
                    var vehicle = DB.data[DB.data.Count - 1];
                    value.id = vehicle.id + 1;
                }

                DB.data.Add(value); //if vehicle don't exist

                this.saveReport(value.id, "Insert");
            }
        }

        // PUT: api/Vehicles/5
        [HttpPut]
        public void Put([FromBody] List<Vehicle> vehicles)
        {
            Vehicle veh = null;

            foreach (Vehicle value in vehicles)
            {
                //find vehicle for update
                veh = DB.data.FirstOrDefault(d => d.id == value.id);

                if (veh != null)
                {
                    veh.model = value.model;
                    veh.year = value.year;
                    veh.licenceNumber = value.licenceNumber;
                    veh.power = value.power;
                    veh.topSpeed = value.topSpeed;
                    veh.km = value.km;
                    veh.torque = value.torque;
                    veh.co2Emissions = value.co2Emissions;
                    veh.euroEmissionStandard = value.euroEmissionStandard;
                    veh.height = value.height;
                    veh.wheelbase = value.wheelbase;
                    veh.turningCircle = value.turningCircle;
                    veh.engineSize = value.engineSize;
                    veh.cylinders = value.cylinders;
                    veh.valves = value.valves;
                    veh.fuelType = value.fuelType;
                    veh.transmission = value.transmission;
                    veh.gearbox = value.gearbox;
                    veh.drivetrain = value.drivetrain;
                    veh.milesPerTank = value.milesPerTank;
                    veh.length = value.length;

                    this.saveReport(value.id, "Update");

                }
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete([FromBody]List<int> ids)
        {
            foreach (int id in ids)
            {
                var itemToRemove = DB.data.SingleOrDefault(r => r.id == id);
                if (itemToRemove != null)
                {
                    DB.data.Remove(itemToRemove);
                    this.saveReport(id, "Delete");
                }
            }
        }
    }
}
