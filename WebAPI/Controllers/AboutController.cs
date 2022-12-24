using ITVisions.Linq.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{

 public record DatabaseInfo(long FlightCount, long PassengerCount, long EmployeeCount, long PersonCount, long AirportCount);

 // https://localhost:7131/api/About/DatabaseInfo
 [HttpGet(Name = "DatabaseInfo")]
 [HttpGet("DatabaseInfo")]
 public DatabaseInfo Get()
 {
  var ctx = new DA.WWWingsContext();
  var db = new DatabaseInfo(ctx.Flight.Count(), ctx.Passenger.Count(), ctx.Employee.Count(), ctx.Person.Count(), ctx.Airport.Count());
  return db;
 }
}