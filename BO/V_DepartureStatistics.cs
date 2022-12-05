using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

public partial class V_DepartureStatistics : BOBase
{
    private string _departure;
    public string departure   
    { 
      get => _departure ;
      set => Set(value, ref _departure); 
    }

    private int? _FlightCount;
    public int? FlightCount   
    { 
      get => _FlightCount ;
      set => Set(value, ref _FlightCount); 
    }
}
