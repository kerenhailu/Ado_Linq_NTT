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
    public class RoomController : ApiController
    {
       string stringCollection=@"Data Source=laptop-0hsc4h8o;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        List<Room>ListOfRooms=new List<Room>();
        // GET: api/Room
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringCollection))
                {
                    conn.Open();
                    string query = @"SELECT * FROM Room";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dataFromDB = cmd.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            ListOfRooms.Add((new Room(dataFromDB.GetInt32(0), dataFromDB.GetInt32(1), dataFromDB.GetString(2), dataFromDB.GetBoolean(3), dataFromDB.GetInt32(4))));
                        }
                        conn.Close();
                        return Ok(new { ListOfRooms });
                    }
                    return Ok(new { ListOfRooms });
                }
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

        // GET: api/Room/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringCollection))
                {
                    conn.Open();
                    string query = $@"SELECT * FROM Room WHERE Room.id={id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dataFromDB = cmd.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        while (dataFromDB.Read())
                        {
                            Room RoomID = new Room(dataFromDB.GetInt32(0), dataFromDB.GetInt32(1), dataFromDB.GetString(2), dataFromDB.GetBoolean(3), dataFromDB.GetInt32(4));

                            conn.Close();
                            return Ok(new { RoomID });
                        }
                    }
                    return Ok(new { ListOfRooms });
                }
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

        // POST: api/Room
        public IHttpActionResult Post([FromBody]Room room)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringCollection))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Room(RoomNumber,TYPE,IsBlank,Price)
                       VALUES({room.RoomNumber},'{room.TYPE}','{room.IsBlank}',{room.Price})";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsEffected = command.ExecuteNonQuery();
                    connection.Close();
                    return Ok(rowsEffected);
                    
                }
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

        // PUT: api/Room/5
        public IHttpActionResult Put(int id, [FromBody]Room room)
        {
            using (SqlConnection connection = new SqlConnection(stringCollection))
            {
                connection.Open();
                string query = $@"UPDATE Room 
                                SET RoomNumber = {room.RoomNumber}, TYPE='{room.TYPE}', IsBlank='{room.IsBlank}', Price='{room.Price}'
                                 WHERE Room.id={id}";
                SqlCommand command = new SqlCommand(query, connection);
                //int rowsEffected = command.ExecuteNonQuery();
                connection.Close();
                return Ok("putttttttttt");
            }
        }

        // DELETE: api/Room/5
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringCollection))
            {
                connection.Open();
                string query = $@"DELETE FROM Room
                                    WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                int rowEffected = command.ExecuteNonQuery();
                connection.Close();
                //return Ok(rowEffected);
                return Ok("you delete");
            }
        }
    }
}
