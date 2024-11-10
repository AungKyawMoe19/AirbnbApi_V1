using AirbnbApi.Data;
using AirbnbApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirbnbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ListingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/listings?location=Paris&minPrice=100&maxPrice=500
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Listing>>> GetListings(
            string location = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            var query = _context.Listings.AsQueryable();

            // Filter by location if it's provided
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(l => l.Location.Contains(location));
            }

            // Filter by min price if provided
            if (minPrice.HasValue)
            {
                query = query.Where(l => l.PricePerNight >= minPrice);
            }

            // Filter by max price if provided
            if (maxPrice.HasValue)
            {
                query = query.Where(l => l.PricePerNight <= maxPrice);
            }

            var listings = await query.ToListAsync();
            return Ok(listings);
        }
    }
}
