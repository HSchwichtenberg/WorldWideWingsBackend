using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// A Passenger is a specialization of a Person.
/// </summary>
public partial class Passenger : BOBase
{
    private int _PersonID;
    public int PersonID   
    { 
      get => _PersonID ;
      set => Set(value, ref _PersonID); 
    }

    private DateTime? _CustomerSince;
    public DateTime? CustomerSince   
    { 
      get => _CustomerSince ;
      set => Set(value, ref _CustomerSince); 
    }

    private string _PassengerStatus;
    public string PassengerStatus   
    { 
      get => _PassengerStatus ;
      set => Set(value, ref _PassengerStatus); 
    }

    private Person _Person ;

    public Person Person
    { 
      get => _Person ;
      set => Set(value, ref _Person); 
    }  


    public virtual ObservableCollection<Flight> Flight_FlightNo { get; } = new ObservableCollection<Flight>();
}
