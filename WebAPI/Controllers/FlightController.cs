using BL;
using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property,
       AllowMultiple = false, Inherited = true)]
public class FromPath : Attribute, IBindingSourceMetadata, IModelNameProvider
{
 /// <inheritdoc />
 public BindingSource BindingSource => BindingSource.Custom;

 /// <inheritdoc />
 public string Name { get; set; }
}

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
 [HttpGet("Route/{depature}/{destination}")]
 public List<Flight> Route(string? depature, string? destination)
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlightSet(depature, destination);
  }
 }

 /// <summary>
 /// https://localhost:7131/api/Flight/berlin/rome
 /// </summary>
 /// <param name="depature"></param>
 /// <param name="destination"></param>
 /// <returns></returns>
 [HttpGet("Departure/{depature}")]
 public List<Flight> Departure(string? depature)
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlightSet(depature, null);
  }
 }


 /// <summary>
 /// https://localhost:7131/api/Flight/berlin/rome

 /// </summary>
 /// <param name="depature"></param>
 /// <param name="destination"></param>
 /// <returns></returns>
 [HttpGet("query")]
 public List<Flight> Query(string departure = "", string? destination = "", int skip = -1, int take = -1)
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlightSet(departure, destination, skip, take);
  }
 }


 /// <summary>
 /// https://localhost:7131/api/Flight/berlin/rome
 /// Problem: Optionale Parameter: https://stackoverflow.com/questions/35011192/how-to-define-an-optional-parameter-in-path-using-swagger
 /// </summary>
 /// <param name="departure"></param>
 /// <param name="destination"></param>
 /// <returns></returns>
 [HttpGet("query2/{depature?}/{destination?}/{skip:int?}/{take:int?}")]
 public List<Flight> Get(string departure = "", string? destination = "", int skip = -1, int take = -1)
 {
  using (var bm = new FlightManager())
  {
   return bm.GetFlightSet(departure, destination, skip, take);
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
