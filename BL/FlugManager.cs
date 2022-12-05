using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BO;
using DA;
using ITVisions.EFCore;

namespace BL
{
 /// <summary>
 /// Datenmanager für Flight-Entitäten
 /// abgeleitet von DataManagerBase
 /// </summary>
 public class FlightManager : EntityManagerBase<WWWingsContext, Flight>
 {
  public FlightManager() 
  {  }

  ///<summary>
  /// Dieser Konstruktur muss internal sein, denn sonst würde das WebAPI eine Referenz auf EF brauchen!!!
  /// </summary>
  internal FlightManager(WWWingsContext kontext = null, bool tracking = false) : base(kontext, tracking)
  {   }

  public Flight GetFlight(int FlightID)
  {
     return ctx.Flight.Find(FlightID);
  }

  public List<Flight> GetFlightSet(string Departure, string Destination)
  {
   // Nutzung der Query-Hilfsmethode aus der Basisklasse
   var q = from f in ctx.Flight select f;

   // Eigentliche Logik für das Zusammensetzen der Abfrage
   if (!String.IsNullOrEmpty(Departure)) q = from f in q
                                                   where f.Departure == Departure
                                                   select f;

   if (!String.IsNullOrEmpty(Destination)) q = q.Where(f => f.Destination == Destination);

   // Ausführen der Abfrage
   List<Flight> ergebnis = q.ToList();

   return ergebnis;
  }

  public List<string> GetAirportSet()
  {
   var l1 = ctx.Flight.Select(f => f.Departure).Distinct();
   var l2 = ctx.Flight.Select(f => f.Destination).Distinct();
   var l3 = l1.Union(l2).Distinct();
   return l3.OrderBy(z => z).ToList();
  }


  /// <summary>
  /// Implementierung einer Kapselung von SaveChanges() direkt in einer konkreten Datenzugriffsmanagerklasse
  /// Rückgabewert ist die Summe der Anzahl der gespeicherten neuen, geänderten und gelöschten Datensätze
  /// </summary>
  /// <returns></returns>
  public int Save()
  {
   return ctx.SaveChanges();
  }

  /// <summary>
  /// Änderungen an einer Liste von Passengeren speichern
  /// Die neu hinzugefügten Passengere muss die Routine wieder zurückgeben, da die IDs für die 
  /// neuen Passengere erst beim Speichern von der Datenbank vergeben werden
  /// </summary>
  public List<Flight> Save(List<Flight> Flight, out string statistik)
  {
   return Save<Flight>(Flight, out statistik);
  }

  /// <summary>
  /// Reduziert die Anzahl der freie Plätzen auf dem genannten Flight, sofern die Plätze noch verfügbar sind. Liefert true, wenn  erfolgreich, sonst false.
  /// </summary>
  /// <param name="flightNo"></param>
  /// <param name="seats"></param>
  /// <returns>true, wenn erfolgreich</returns>
  public bool ReduceFreeSeats(int flightNo, short seats)
  {
   var einzelnerFlight = GetFlight(flightNo);
   if (einzelnerFlight != null)
   {
    if (einzelnerFlight.FreeSeats >= seats)
    {
     einzelnerFlight.FreeSeats -= seats;
     ctx.SaveChanges();
     return true;
    }
   }
   return false;
  }

  #region Beispiel für GroupBy
  //public class DepartureStatistik
  //{
  // public string Ort { get; set; }
  // public int Anzahl { get; set; }
  //}

  //public List<DepartureStatistik> GetFluegeProDeparture()
  //{
  // System.Data.Entity.Database.SetInitializer<WWWingsContext_EF>(null);
  // using (var ctx = new WWWings.DZ.EF.WWWingsContext_EF())
  // {
  //  //Console.WriteLine(ctx.Database.Connection.ConnectionString);    ctx.Flight.ToList();
  //  var gruppenSet = new List<DepartureStatistik>();
  //  var gruppen = from p in ctx.Flight
  //                orderby p.FreiePlaetze
  //                group p by p.Departure into g
  //                select new { Ort = g.Key, Anzahl = g.Count() };

  //  //Console.WriteLine("Anzahl: " + gruppen.Count());

  //  //OO - Mapping
  //  foreach (var g in gruppen)
  //  {
  //   gruppenSet.Add(new DepartureStatistik() { Anzahl = g.Anzahl, Ort = g.Ort });
  //  }
  //  return gruppenSet;
  // }

  //}
  #endregion

 }
}
