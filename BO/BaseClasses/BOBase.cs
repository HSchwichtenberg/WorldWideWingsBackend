using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BO;

/// <summary>
/// Base Class with INotifyPropertyChanged and INotifyPropertyChanging for all Entities
/// </summary>
public abstract class BOBase : INotifyPropertyChanged, INotifyPropertyChanging
{
 public event PropertyChangedEventHandler PropertyChanged;
 public event PropertyChangingEventHandler PropertyChanging;

 protected void Set<T>(T value, ref T field,
    [CallerMemberName] string propertyName = "")
 {
  if (!Equals(field, value))
  {
   PropertyChanging?.Invoke(this,
    new PropertyChangingEventArgs(propertyName));
   field = value; // Change Value now!
   PropertyChanged?.Invoke(this,
       new PropertyChangedEventArgs(propertyName));
  }
 }
}