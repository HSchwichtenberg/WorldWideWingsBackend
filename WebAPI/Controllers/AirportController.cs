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
 /// WebAPI /api/Flighthafen
 /// </summary>
 /// 
 [Route("api/[controller]")]
 public class AirportController : Controller
 {
  [HttpGet()]
  public List<string> Get()
  {
   using (var bm = new FlightManager())
   {
    return bm.GetAirportSet();
   }
  }
 }
}
