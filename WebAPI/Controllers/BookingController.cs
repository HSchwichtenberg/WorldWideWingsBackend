using BL;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers;

/// <summary>
/// WebAPI /api/Buchung
/// </summary>
[Route("api/[controller]")]
public class BookingController : Controller
{
 [HttpPost()]
 public JsonResult Post([FromBody] Booking buchung)
 {
  var bm = new BookingManager();

  string ergebnis = bm.CreateBuchung(buchung.FlightNo, buchung.PassengerID);

  if (ergebnis == "OK")
  {
   var r = new JsonResult("Gebucht!");
   r.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status201Created;
   return r;
  }
  else
  {
   var r = new JsonResult(ergebnis);
   r.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status406NotAcceptable;
   return r;
  }
 }
}
