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
    public class ProduceController : ControllerBase
    {
        private List<ProduceListing> produceListings = new List<ProduceListing>
            {
            new ProduceListing(1, 1, "Tomatoes", "Vegetable", 2.5, 100, true, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-3), "Fresh and juicy tomatoes from John's farm."),
            new ProduceListing(2, 2, "Strawberries", "Fruit", 3.0, 50, true, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-4), "Sweet and ripe strawberries from Jane's farm."),
            new ProduceListing(3, 3, "Carrots", "Vegetable", 1.8, 200, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-6), "Crunchy and sweet carrots from Bob's farm."),
            new ProduceListing(4, 4, "Apples", "Fruit", 2.0, 150, true, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), "Crisp and delicious apples from Alice's farm.")
        };

        [HttpGet]
        public List<ProduceListing> GetProduceListings()
        {
            return produceListings;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduceListing(int id)
        {
            var produceListing = produceListings.FirstOrDefault(p => p.ListingId == id);

            if (produceListing == null)
            {
                return NotFound();
            }

            return Ok(produceListing.GetFormattedSummary());
        }
    }
}