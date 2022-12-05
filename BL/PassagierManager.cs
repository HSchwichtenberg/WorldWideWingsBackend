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
 /// Datenmanager für Passenger-Entitäten
 /// </summary>
 public class PassengerManager : DataManagerBase<WWWingsContext>
 {

   /// <summary>
  /// Öffentlicher Konstruktor für GL
  /// </summary> 
  /// 
  public PassengerManager() : this(null)
  {  }

  ///<summary>
  /// Dieser Konstruktur muss internal sein, denn sonst würde das WebAPI eine Referenz auf EF brauchen!!!
  /// </summary>
  internal PassengerManager(WWWingsContext kontext = null)
  : base(kontext)
  {  }

  /// <summary>
  /// Holt einen Passenger
  /// </summary>
  public Passenger GetPassenger(int PassengerID)
  {
   // .OfType<Passenger>() notwendig wegen Vererbung
   var abfrage = from p in ctx.Passenger where p.PersonID == PassengerID select p;
   return abfrage.SingleOrDefault();
  }

  /// <summary>
  /// Holt alle Passengere mit einem Namensbestandteil
  /// </summary>
  public List<Passenger> GetPassenger(string Namensbestandteil)
  {
   // .OfType<Passenger>() notwendig wegen Vererbung
   var abfrage = from p in ctx.Passenger where p.Person.GivenName.Contains(Namensbestandteil) || p.Person.Surname.Contains(Namensbestandteil) select p;
   return abfrage.ToList();
  }

  /// <summary>
  /// Holt alle Passengere mit einem Namensbestandteil
  /// </summary>
  public List<Passenger> GetPassenger()
  {
   // .OfType<Passenger>() notwendig wegen Vererbung
   var abfrage = from p in ctx.Passenger select p;
   return abfrage.ToList();
  }

  /// <summary>
  /// Füge einen Passenger zu einem Flight hinzu
  /// </summary>
  public bool AddPassengerToFlight(int PassengerID, int FlightID)
  {
   try
   {
    var fm = new FlightManager(ctx, true);

    Flight f = fm.GetFlight(FlightID);
    Passenger p = GetPassenger(PassengerID);
    f.Passenger_Person.Add(p);

    int anz = ctx.SaveChanges();
    if (anz != 1) return false;
    fm.Dispose();
    return true;
   }
   catch (Exception)
   {
    return false;
   }
  }

  /// <summary>
  /// Änderungen an einer Liste von Passengeren speichern
  /// Die neu hinzugefügten Passengere muss die Routine wieder zurückgeben, da die IDs für die 
  /// neuen Passengere erst beim Speichern von der Datenbank vergeben werden
  /// Statistik liefert einen Kette der Form "Geändert: 0 Neu: 1 Gelöscht: 0"
  /// </summary>
  public List<Passenger> SavePassenger(List<Passenger> Passenger, out string Statistik)
  {
   return Save(Passenger, out Statistik);
  }
 }
}
