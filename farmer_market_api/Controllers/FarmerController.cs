using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmer_market_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace farmer_market_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private List<Farmer> farmers = new List<Farmer>
        {
            new Farmer(1, "John Doe", "john.doe@example.com", "123-456-7890", "123 Main St", "Ontario", 4.5, true),
            new Farmer(2, "Jane Smith", "jane.smith@example.com", "098-765-4321", "456 Oak Ave", "Quebec", 4.0, true),
            new Farmer(3,"Bob Johnson", "bob.johnson@example.com", "555-555-5555", "789 Pine Rd", "Alberta", 4.8, true),
            new Farmer(4, "Alice Williams", "alice.williams@example.com", "111-111-1111", "321 Elm St", "BC", 4.2, true)
        };

        [HttpGet]
        public List<Farmer> GetListOfFarmers()
        {
            return farmers;
        }

        [HttpPost]
        public List<Farmer> CreateFarmer([FromBody] Farmer farmer)
        {
            farmers.Add(farmer);
            return farmers;
        }

        [HttpDelete]
        public List<Farmer> Delete([FromQuery] string name)
        {
            var farmer = farmers.FirstOrDefault(f => f.Name == name);

            if (farmer != null)
            {
                farmers.Remove(farmer);
            }

            return farmers;
        }

        [HttpPut]
        public List<Farmer> UpdateFarmers([FromBody] Farmer updatedFarmer)
        {
            var farmer = farmers.FirstOrDefault(f => f.Name == updatedFarmer.Name);

            if (farmer != null)
            {
                var index = farmers.IndexOf(farmer);

                farmers[index] = new Farmer
                {
                    Name = updatedFarmer.Name,
                    Email = updatedFarmer.Email,
                    Phone = updatedFarmer.Phone,
                    Address = updatedFarmer.Address,
                    Province = updatedFarmer.Province,
                    Rating = updatedFarmer.Rating,
                    IsAvailable = updatedFarmer.IsAvailable
                };
            }

            return farmers;
        }
    }
}