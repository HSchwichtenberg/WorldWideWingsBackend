using BL;
using BO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/// <summary>
/// WebAPI /api/Flight
/// </summary>
[Route("api/[controller]")]
public class FlightController : Controller
{

 /// <summary>
 /// http://localhost:7131/api/Flight/101
 /// </summary>
 /// <param name="id"></param>
 /// <returns></returns>
 [HttpGet("{id:int}")]
 public Flight Get(int id)
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlight(id);
  }
 }

 /// <summary>
 /// https://localhost:7131/api/Flight/berlin/rome
 /// </summary>
 /// <param name="depature"></param>
 /// <param name="destination"></param>
 /// <returns></returns>
 [HttpGet("{depature?}/{destination?}")]
 public List<Flight> Get(string depature="", string? destination = "")
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlightSet(depature, destination);
  }
 }

 [HttpPost()]
 public void Post(Flight Flight)
 {
  using (var bm = new FlightManager())
  {
   bm.New(Flight);
  }
 }
}
