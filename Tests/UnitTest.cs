using System;
using Xunit;
using Xunit.Priority;
using DeepEqual;
using DeepEqual.Syntax;
//using BO;
//using BL;

namespace Tests
{
 [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
 public class UnitTest
 {
  [Fact, Priority(2)] // Priorit�t nur nutzen, wenn man sie wirklich braucht. Im Regelfall unabh�ngige Tests schreiben!
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
