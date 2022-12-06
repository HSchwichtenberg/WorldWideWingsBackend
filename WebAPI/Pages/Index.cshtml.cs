using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Pages;
public class IndexModel : PageModel
{
 private readonly ILogger<IndexModel> _logger;

 public IndexModel(ILogger<IndexModel> logger)
 {
  _logger = logger;
 }

 //public List<Flight> FlightSet { get; set; }

 public string SQLServerVersion { get; set; }

 public void OnGet()
 {
  var ctx = new DA.WWWingsContext();
  ctx.Database.OpenConnection();
  SQLServerVersion = ctx.Database.GetDbConnection().ServerVersion;
  ctx.Database.CloseConnection();
  //using var ctx = new DA.WWWingsContext();
  //FlightSet = ctx.Flight.Take(100).ToList();
 }
}
