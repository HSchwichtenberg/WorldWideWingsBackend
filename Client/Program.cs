using System;
using System.Linq;
using System.Threading;
using ITVisions;
using ITVisions.EFCore.Logging;
using Microsoft.EntityFrameworkCore;
using WWWings_Generator;
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

   Datagenerator.Init_DB();

   CUI.Success("ENDE!");
   Console.ReadLine();
  }

 }
}