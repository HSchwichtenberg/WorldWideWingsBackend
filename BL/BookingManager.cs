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
 /// Geschäftslogik für Buchung, verwendet FlightManager und PassengerManager
 /// </summary>
 public class BookingManager 
 {

  /// <summary>
  /// Flugbuchung erstellen, wobei dafür sowohl die eigentliche Buchung als auch die Reduzierung der Anzahl der freien Plätze in einer Transaktion erfolgen muss! Methode liefert "OK", wenn die Buchung erfolgreich war, sonst den Fehlertext.
  /// </summary>
  public string CreateBuchung(int FlightID, int PassengerID)
  {
   // Transaktion, nur erfolgreich wenn Platzanzahl reduziert und Buchung erstellt!
   using (var ctx = new WWWingsContext())
   {
    using (var transaction = ctx.Database.BeginTransaction())
    {
     try
     {
      FlightManager fm = new FlightManager(ctx);
      PassengerManager pm = new PassengerManager(ctx);

      if (!fm.ReduceFreeSeats(FlightID, 1))
      {
        return "Fehler: Kein Platz auf diesem Flight vorhanden!";
      }
      if (!pm.AddPassengerToFlight(PassengerID, FlightID))
      {
       return "Fehler: Buchung nicht möglich!";
      }
      //  Transaktion erfolgreich abschließen
      transaction.Commit();

      fm.Dispose();
      pm.Dispose();
      return "OK";
     }
     catch (Exception ex)
     {
      return "Unerwarteter Fehler: " + ex.Message;
     }
     finally
     {
      Console.WriteLine("Rollback!");
     }
    } // End using Transaction
   } // End using context
  }
 }
}

