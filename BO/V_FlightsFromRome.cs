using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

public partial class V_FlightsFromRome : BOBase
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

    private DateTime _FlightDate;
    public DateTime FlightDate   
    { 
      get => _FlightDate ;
      set => Set(value, ref _FlightDate); 
    }

    private string _Destination;
    public string Destination   
    { 
      get => _Destination ;
      set => Set(value, ref _Destination); 
    }

    private bool _NonSmokingFlight;
    public bool NonSmokingFlight   
    { 
      get => _NonSmokingFlight ;
      set => Set(value, ref _NonSmokingFlight); 
    }

    private short _Seats;
    public short Seats   
    { 
      get => _Seats ;
      set => Set(value, ref _Seats); 
    }

    private string _Memo;
    public string Memo   
    { 
      get => _Memo ;
      set => Set(value, ref _Memo); 
    }

    private short? _FreeSeats;
    public short? FreeSeats   
    { 
      get => _FreeSeats ;
      set => Set(value, ref _FreeSeats); 
    }

    private int? _Pilot_PersonID;
    public int? Pilot_PersonID   
    { 
      get => _Pilot_PersonID ;
      set => Set(value, ref _Pilot_PersonID); 
    }
}
