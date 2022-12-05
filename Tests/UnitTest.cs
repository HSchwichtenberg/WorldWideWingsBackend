using System;
using Xunit;
using Xunit.Priority;
using DeepEqual;
using DeepEqual.Syntax;
using BL;
//using BO;
//using BL;

namespace Tests
{


 [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
 public class UnitTest
 {
  [Fact, Priority(10)] // Priorität nur nutzen, wenn man sie wirklich braucht. Im Regelfall unabhängige Tests schreiben!
  public void FlightTest()
  {
   var bl = new FlightManager();
   var f = bl.GetFlight(101);
   Assert.Equal(101, f.FlightNo);
  }

  [Fact, Priority(2)] // Priorität nur nutzen, wenn man sie wirklich braucht. Im Regelfall unabhängige Tests schreiben!
  public void Math()
  {
   Assert.True(1 + 1 == 2);
  }

  [Fact, Priority(1)]
  public void Runtime()
  {
   Assert.Contains(".NET", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
  }

  [Fact, Priority(3)]
  public void Objects()
  {
   var p1 = new Guid();
   var p2 = Guid.Empty;
   p1.ShouldDeepEqual(p2);
  }
 }
}
