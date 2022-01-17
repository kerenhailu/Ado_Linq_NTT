using Ado_Linq_NTT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ado_Linq_NTT.Controllers.API
{
    public class GuestController : ApiController
    {
        HotelDataContext DataContext = new HotelDataContext();
        // GET: api/Guest
        public IHttpActionResult Get()
        {
            try
            {
                List<Guest> guests = DataContext.Guests.ToList();
                return Ok(new { guests });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Guest/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Guest guest = await DataContext.Guests.FindAsync(id);
                return Ok(new { guest });
            }
            catch (SqlException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // POST: api/Guest
        public async Task<IHttpActionResult> Post([FromBody] Guest guest)
        {
            try
            {
                DataContext.Guests.Add(guest);
                await DataContext.SaveChangesAsync();
                List<Guest> Guests = DataContext.Guests.ToList();
                return Ok(new { Guests });
            }
            catch (SqlException ex)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/Guest/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Guest guest)
        {
            try
            {
                Guest guestToChange = await DataContext.Guests.FindAsync(id);
                guestToChange.Name = guest.Name;
                guestToChange.Birthday = guest.Birthday;
                guestToChange.Gender = guest.Gender;
                guestToChange.CheckIn = guest.CheckIn;
                await DataContext.SaveChangesAsync();
                List<Guest> Guests = DataContext.Guests.ToList();
                return Ok(new { Guests });
            }
            catch (SqlException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE: api/Guest/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Guest guestToDelete = await DataContext.Guests.FindAsync(id);
                DataContext.Guests.Remove(guestToDelete);
                await DataContext.SaveChangesAsync();
                return Ok();
            }
            catch (SqlException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
