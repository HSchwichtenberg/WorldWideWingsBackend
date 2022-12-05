using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

public partial class V_Booking_DETAILS : BOBase
{
    private int _FlightNo;
    public int FlightNo   
    { 
      get => _FlightNo ;
      set => Set(value, ref _FlightNo); 
    }

    private string _Departure;
    public string Departure   
    { 
      get => _Departure ;
      set => Set(value, ref _Departure); 
    }

    private string _Destination;
    public string Destination   
    { 
      get => _Destination ;
      set => Set(value, ref _Destination); 
    }

    private DateTime _FlightDate;
    public DateTime FlightDate   
    { 
      get => _FlightDate ;
      set => Set(value, ref _FlightDate); 
    }

    private string _Fullname;
    public string Fullname   
    { 
      get => _Fullname ;
      set => Set(value, ref _Fullname); 
    }
}
