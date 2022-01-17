using Ado_Linq_NTT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ado_Linq_NTT.Controllers.API
{
    public class OrdersController : ApiController
    {
        DezinerDataContext dataContext = new DezinerDataContext();
        // GET: api/Orders
        public IHttpActionResult Get()
        {
            try
            {
                List<Order> orders = dataContext.Orders.ToList();
                return Ok(new { orders });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            try { 
            Order order = dataContext.Orders.First(item => item.Id == id);
            return Ok(new { order });
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

        // POST: api/Orders
        public IHttpActionResult Post([FromBody] Order order)
        {
            try { 
            dataContext.Orders.InsertOnSubmit(order);
            dataContext.SubmitChanges();
            List<Order> orders = dataContext.Orders.ToList();
            return Ok(new { orders });
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

        // PUT: api/Orders/5
        public IHttpActionResult Put(int id, [FromBody] Order order)
        {
            try { 
            return Ok();
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

        // DELETE: api/Orders/5
        public IHttpActionResult Delete(int id)
        {
            try { 
            return Ok();
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
    }
}
