using BO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Pages;
public class IndexModel : PageModel
{
 private readonly ILogger<IndexModel> _logger;

 public IndexModel(ILogger<IndexModel> logger)
 {
  _logger = logger;
 }

 //public List<Flight> FlightSet { get; set; }

 public void OnGet()
 {
  //using var ctx = new DA.WWWingsContext();
  //FlightSet = ctx.Flight.Take(100).ToList();
 }
}
