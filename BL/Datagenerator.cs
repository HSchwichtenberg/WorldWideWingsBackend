using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DA;
using BO;
using Microsoft.EntityFrameworkCore;

namespace WWWings_Generator
{
 /// <summary>
 /// Generiert zufällige Testdaten für die Datenbank aus häufigen Vor- und Nachnamen sowie ausgewählten Städten
 /// </summary>
 public class Datagenerator
 {

  static string[] AIRPORTS = { "Berlin", "Frankfurt", "München", "Hamburg", "Köln/Bonn", "Rom", "London", "Paris", "Mailand", "Prag", "Moskau", "New York", "Seattle", "Essen/Mülheim", "Kapstadt", "Madrid", "Oslo", "Dallas", "Graz", "Tiflis", "Amman", "Tokio" };

  // Häufigste Vor- und Nachnamen
  // Quelle: http://de.wikipedia.org/wiki/Liste_der_h%C3%A4ufigsten_Familiennamen_in_Deutschland
  static string[] SURNAMES = { "Müller", "Schmidt", "Schneider", "Fischer", "Weber", "Meyer", "Wagner", "Becker", "Schulz", "Hoffmann", "Schäfer", "Koch", "Bauer", "Richter", "Klein", "Wolf", "Schröder", "Neumann", "Schwarz", "Zimmermann" };

  // Quelle: http://www.beliebte-vornamen.de/3467-alle-spitzenreiter.htm
  static string[] FIRSTNAMES = { "Leon", "Hannah", "Lukas", "Anna", "Leonie", "Marie", "Niklas", "Sarah", "Jan", "Laura", "Julia", "Lisa", "Kevin" };

  // Politiker-Namenskarusell :-)
  static string[] PilotenNachnamen = { "Gysi", "Stoiber", "Koch", "Steinmeyer", "Schröder", "Merkel", "Westerwelle", "Beck", "Lafontaine", "Trittin", "Roth", "Scholz", "Bärbock", "Habeck", "Lindner" };
  static string[] PilotenVornamen = { "Edmund", "Olaf", "Roland", "Gerhard", "Angela", "Joschka", "Guido", "Gregor", "Kurt", "Frank-Walter", "Oskar", "Jürgen", "Claudia", "Olaf", "Annalena", "Robert", "Christian" };

  const int ANZFluege = 50000;
  const int ANZPass = 20000;
  static string[] PassagierStatus = { "A", "B", "C" };

  static System.Random rnd = new Random(DateTime.Now.Millisecond);

  public static void Init_DB(bool delete = false)
  {

   Console.WriteLine("DB WWWings Mini Initialisieren");

   DA.WWWingsContext db = new WWWingsContext();

   Console.WriteLine("Flüge zu Beginn: " + db.Flight.Count());
   Console.WriteLine("Passagiere zu Beginn: " + db.Passenger.Count());
   // Alle Buchungen löschen!
   if (delete)
   {
    db.Database.ExecuteSqlRaw("Delete from PassagierFlug");
    db.Database.ExecuteSqlRaw("Delete from FlugSet");
    db.Database.ExecuteSqlRaw("Delete from PersonSet_Passagier");
    db.Database.ExecuteSqlRaw("Delete from PersonSet_Pilot");
    db.Database.ExecuteSqlRaw("Delete from PersonSet");
   }

   Console.WriteLine("Flüge nach Löschen: " + db.Flight.Count());
   Console.WriteLine("Personen nach Löschen: " + db.Passenger.Count());

   //Init_Passagiere(db);
   //Init_Piloten(db);
   Init_Fluege(db);
   Init_Buchungen(db);
  }

  /// <summary>
  /// Menge von Flügen erzeugen
  /// </summary>
  private static System.Random Init_Fluege(WWWingsContext db)
  {
   Console.WriteLine("Erzeuge Flüge...");

   var Fluege = from f in db.Flight select f;
   int Start = 10000;

   for (int i = Start; i < (Start + ANZFluege); i++)
   {

    if (i % 100 == 0) Console.WriteLine("FLUG #" + i);
    Flight FlugNeu = new Flight();
    FlugNeu.FlightNo = i;
    FlugNeu.Departure = AIRPORTS[rnd.Next(0, AIRPORTS.Length - 1)];
    FlugNeu.Destination = AIRPORTS[rnd.Next(0, AIRPORTS.Length - 1)]; ;
    if (FlugNeu.Departure == FlugNeu.Destination) { i--; continue; } // Keine Rundflüge!
    FlugNeu.FreeSeats = Convert.ToInt16(new System.Random(i).Next(250));
    FlugNeu.Seats = 250;
    FlugNeu.FlightDate = DateTime.Now.AddDays((double)FlugNeu.FreeSeats).AddMinutes((double)FlugNeu.FreeSeats * 7);

    FlugNeu.Pilot_PersonID = db.Pilot.ToList()[rnd.Next(db.Pilot.Count() - 1)].PersonID;

    db.Flight.Add(FlugNeu);
    try
    {
     db.SaveChanges();
    }
    catch (Exception ex)
    {
     Console.WriteLine("FLUG:   " + FlugNeu.FlightNo + ":" + FlugNeu.Departure + " -> " + FlugNeu.Destination + ": " + ex.Message.ToString());
     db.Flight.Remove(FlugNeu);
    }
   }
   Console.WriteLine("Flüge nach dem Einfügen: " + db.Flight.Count());
   return rnd;
  }

  private static void Init_Buchungen(WWWingsContext db)
  {
   int k = 0;
   System.Random rnd5 = new Random();
   Console.WriteLine("Erzeuge Buchungen...");
   var Fluege2 = from f in db.Flight select f;

   Passenger[] PassagierArray = db.Passenger.ToArray();
   foreach (Flight f in Fluege2.ToList())
   {
    k++;
    if (k % 100 == 0) Console.WriteLine(k);

    for (int j = 1; j < 10; j++)
    {
     Random rnd2 = new System.Random(System.DateTime.Now.Millisecond);
     // Wähle Zufällig einen Passagier
     Passenger p = PassagierArray[Convert.ToInt16(rnd5.Next(PassagierArray.Count()))];
     Console.WriteLine("BUCHUNG: " + f.FlightDate + " ->  " + p.PersonID);
     // Buchung anlegen
     f.Passenger_Person.Add(p);

     try // Weil doppelte möglich sind durch Zufallsauswahl!
     {
      db.SaveChanges();
     }
     catch (Exception ex)
     {
      Console.WriteLine(ex.InnerException.Message);
      f.Passenger_Person.Remove(p);
     }
    }
   }
  }

  private static void Init_Piloten(WWWingsContext db)
  {
   Console.WriteLine("Erzeuge Piloten...");

   for (int PNummer = 1; PNummer <= ANZPass; PNummer++)
   {
    string Vorname = PilotenVornamen[rnd.Next(0, PilotenVornamen.Length - 1)]; ;
    string Nachname = PilotenNachnamen[rnd.Next(0, PilotenNachnamen.Length - 1)]; ;
    Pilot p = new Pilot();
    p.Person = new Employee();
    p.Person.Person = new Person();
    //p.Id = 1000 + PNummer;
    p.Person.Person.Surname = Nachname;
    p.Person.Person.GivenName = Vorname;
    p.Person.Person.Birthday = new DateTime(1940, 1, 1).AddDays(Convert.ToInt32(new Random(DateTime.Now.Millisecond).Next(20000)));
    p.FlightSchool = "Essen";
    db.Pilot.Add(p);
    db.SaveChanges();
    System.Console.WriteLine("PILOT: " + PNummer + ": " + Vorname + " " + Nachname);
   }
   Console.WriteLine("Piloten nach dem Einfügen: " + db.Pilot.Count());
  }

  private static void Init_Passagiere(WWWingsContext db)
  {
   // Passagiere Anlegen
   Console.WriteLine("Erzeuge Passagiere...");

   System.Random rnd2 = new Random();

   for (int PNummer = 1; PNummer <= ANZPass; PNummer++)
   {
    string Vorname = FIRSTNAMES[rnd2.Next(0, FIRSTNAMES.Length - 1)]; ;
    string Nachname = SURNAMES[rnd2.Next(0, SURNAMES.Length - 1)]; ;
    Passenger p = new Passenger();
    p.Person = new Person();
    //  p.ID = 1;
    p.Person.Surname = Nachname;
    p.Person.GivenName = Vorname;
    p.Person.Birthday = new DateTime(1940, 1, 1).AddDays(Convert.ToInt32(new Random(DateTime.Now.Millisecond).Next(20000)));
    p.PersonID = PNummer;

    p.PassengerStatus = PassagierStatus.ElementAt(rnd.Next(3));
    db.Passenger.Add(p);
    db.SaveChanges();
    System.Console.WriteLine("PASSAGIER: " + PNummer + ": " + Vorname + " " + Nachname);

   }
   Console.WriteLine("Passagiere nach dem Anfügen: " + db.Passenger.Count());
  }
 }
}