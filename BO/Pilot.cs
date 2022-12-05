using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// A Pilot is a specialization of an Employees
/// </summary>
public partial class Pilot : BOBase
{
    private int _PersonID;
    public int PersonID   
    { 
      get => _PersonID ;
      set => Set(value, ref _PersonID); 
    }

    private DateTime? _LicenseDate;
    public DateTime? LicenseDate   
    { 
      get => _LicenseDate ;
      set => Set(value, ref _LicenseDate); 
    }

    private string _LicenseType;
    public string LicenseType   
    { 
      get => _LicenseType ;
      set => Set(value, ref _LicenseType); 
    }

    private int? _FlightHours;
    public int? FlightHours   
    { 
      get => _FlightHours ;
      set => Set(value, ref _FlightHours); 
    }

    private string _FlightSchool;
    public string FlightSchool   
    { 
      get => _FlightSchool ;
      set => Set(value, ref _FlightSchool); 
    }

    public virtual ObservableCollection<Flight> Flight { get; } = new ObservableCollection<Flight>();

    private Employee _Person ;

    public Employee Person
    { 
      get => _Person ;
      set => Set(value, ref _Person); 
    }  

}
