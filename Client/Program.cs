using System;
using System.Linq;
using System.Threading;
using ITVisions;
using ITVisions.EFCore.Logging;
using Microsoft.EntityFrameworkCore;
//using BO;
//using BL;

namespace Client
{
 class Program
 {
  static void Main(string[] args)
  {
   CUI.H1("***EFC_Grundstruktur***");
   CUI.H1("(C) Dr. Holger Schwichtenberg 2017-2022");
   Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
   Console.WriteLine(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
   Console.WriteLine("EFCore " + ITVisions.EFCore.EFCoreUtil.GetEFCoreVersion().ToString());

   Console.WriteLine("*** Hier den Datenzugriffscode implementieren ***");

   //CUI.H2("Kontextinstanzierung");
   //using var ctx = new DA.WWWingsContext();
   //Console.WriteLine(ctx.Database.GetConnectionString());
   //ctx.Log();
   //Console.WriteLine(ctx.Flight.ToList().Count);

   //var p1 = ctx.Pilot.Skip(new Random(0).Next(0, 1000)).FirstOrDefault();
   //var p2 = ctx.Pilot.Skip(new Random(1).Next(0, 1000)).FirstOrDefault();

   //int numberOfChanges = 50;
   //CUI.H2($"Performance-Test ({numberOfChanges} Datensatzänderungen)");
   //for (int i = 0; i < 11; i++)
   //{
   // ITVisions.Timer.Run($"{numberOfChanges} Changes", () => TwoChanges(numberOfChanges, ctx, p1, p2));
   //}
   //ITVisions.Timer.PrintResults();

   CUI.Success("ENDE!");
   Console.ReadLine();
  }

  //private static long TwoChanges(int count, DA.WWWingsContext ctx, BO.Pilot p1, BO.Pilot p2)
  //{

  // for (int i = 0; i < count; i++)
  // {
  //  var f = ctx.Flight.Skip(5000+i).FirstOrDefault();
  //  //Console.WriteLine(f.FlightNo);
  //  f.FreeSeats++;
  //  //var c1 = ctx.SaveChanges();
  //  //if (c1 != 1) throw new ApplicationException("Change Tracking Error!");
  //  if (f.Pilot_Person == p1 || f.Pilot_Person == null) f.Pilot_Person = p2;
  //  else f.Pilot_Person = p1;
  //  var c2 = ctx.SaveChanges();
  //  if (c2 != 1) throw new ApplicationException("Change Tracking Error!");
  // }

  // return count;
  //}
 }
}