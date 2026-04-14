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

        private List<string> farmers = new List<string>
        {
            "John Doe",
            "Jane Smith",
            "Bob Johnson",
            "Alice Williams"
        };
        [HttpGet]
        public List<string> GetListOffFarmers()
        {
            return farmers;
        }
        [HttpPost]
        public List<string> createFarmer([FromBody] string name)
        {
            farmers.Add(name);
            return farmers;
        }

        [HttpDelete]
        public List<string> Delete([FromQuery]string name)
        {
            if (farmers.Contains(name))
            {
                farmers.Remove(name);
                return farmers;
            }
            else            
            {
                return farmers;
            }
        }

        [HttpPut]
        public List<string> updateFarmers([FromBody] UpdateRequest request)
        {
            if (farmers.Contains(request.OldName))
            {
                var index = farmers.IndexOf(request.OldName);
                farmers[index] = request.NewName;
                return farmers;
            }
            else
            {
                return farmers;
            }
        }
    }
}