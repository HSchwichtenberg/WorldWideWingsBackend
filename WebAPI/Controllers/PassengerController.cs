using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL;
using BO;

namespace WebAPI.Controllers
{
 /// <summary>
 /// WebAPI /api/Passenger
 /// </summary>
 /// 
 [Route("api/[controller]")]
 public class PassengerController : Controller
 {

  [HttpGet("{id}")]
  public Passenger Get(int id)
  {
   using (var bm = new PassengerManager())
   {
    return bm.GetPassenger(id);
   }
  }

  [HttpGet("name/{name}")]
  public List<Passenger> Get(string name)
  {
   using (var bm = new PassengerManager())
   {
    return bm.GetPassenger(name);
   }
  }

  // POST /api/Passenger
  [HttpPost()]
  public JsonResult PostPassenger([FromBody]List<Passenger> Passengere)
  {
   if (Passengere == null) return new JsonResult("Liste darf nicht leer sein!");
   try
   {
    using (PassengerManager bm = new PassengerManager())
    {
     string statistik;
     bm.SavePassenger(Passengere, out statistik);

     var r = new JsonResult(statistik);
     this.Response.Headers.Add("X-Status", statistik);
     this.Response.Headers.Add("Location", new Uri("http://localhost:8887/api/Passenger/" + Passengere[0].PersonID).ToString());
     r.StatusCode = 201; // Created
     return r;
    }
   }
   catch (Exception e)
   {
    return new JsonResult(e.ToString());
   }

  }
 }
}
