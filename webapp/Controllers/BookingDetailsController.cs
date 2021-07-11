using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.DBContext;
using webapp.Models;

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BookingDetailsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails()
        {
            return await _context.BookingDetails.ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
            var bookingDetails = await _context.BookingDetails.FindAsync(id);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return bookingDetails;
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            bookingDetails.UserId = id; 

            _context.Entry(bookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
            _context.BookingDetails.Add(bookingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetails", new { id = bookingDetails.UserId }, bookingDetails);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingDetails>> DeleteBookingDetails(int id)
        {
            var bookingDetails = await _context.BookingDetails.FindAsync(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            _context.BookingDetails.Remove(bookingDetails);
            await _context.SaveChangesAsync();

            return bookingDetails;
        }

        private bool BookingDetailsExists(int id)
        {
            return _context.BookingDetails.Any(e => e.UserId == id);
        }
    }
}
