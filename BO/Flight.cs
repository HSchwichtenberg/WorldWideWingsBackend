using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// A flight from a Departure City to a Destination City
/// </summary>
public partial class Flight : BOBase
{
    private int _FlightNo;
    /// <summary>
    /// Flight-ID
    /// </summary>
    public int FlightNo   
    { 
      get => _FlightNo ;
      set => Set(value, ref _FlightNo); 
    }

    private string _Airline;
    /// <summary>
    /// 2-Letter-Code according to https://de.wikipedia.org/wiki/Liste_der_IATA-Airline-Codes or custom 3-Letter-Code e.g. WWW for World Wide Wings und NCB for Never-Come-Back-Airline :-)
    /// </summary>
    public string Airline   
    { 
      get => _Airline ;
      set => Set(value, ref _Airline); 
    }

    private string _Departure;
    /// <summary>
    /// Name of Departure City (max 30 Letters)
    /// </summary>
    public string Departure   
    { 
      get => _Departure ;
      set => Set(value, ref _Departure); 
    }

    private string _Destination;
    /// <summary>
    /// Name of Destination City (max 30 Letters)
    /// </summary>
    public string Destination   
    { 
      get => _Destination ;
      set => Set(value, ref _Destination); 
    }

    private DateTime _FlightDate;
    /// <summary>
    /// Date and Time of planned Depature
    /// </summary>
    public DateTime FlightDate   
    { 
      get => _FlightDate ;
      set => Set(value, ref _FlightDate); 
    }

    private bool _NonSmokingFlight;
    /// <summary>
    /// Nowadays, all flights are Non-Smoking
    /// </summary>
    public bool NonSmokingFlight   
    { 
      get => _NonSmokingFlight ;
      set => Set(value, ref _NonSmokingFlight); 
    }

    private short _Seats;
    /// <summary>
    /// Total Number of Seats on this Flight
    /// </summary>
    public short Seats   
    { 
      get => _Seats ;
      set => Set(value, ref _Seats); 
    }

    private short? _FreeSeats;
    /// <summary>
    /// Number of free Seats on this Flight
    /// </summary>
    public short? FreeSeats   
    { 
      get => _FreeSeats ;
      set => Set(value, ref _FreeSeats); 
    }

    private int? _Pilot_PersonID;
    /// <summary>
    /// PersonID of the single Pilot (No Co-Pilots :-| )
    /// </summary>
    public int? Pilot_PersonID   
    { 
      get => _Pilot_PersonID ;
      set => Set(value, ref _Pilot_PersonID); 
    }

    private string _Memo;
    /// <summary>
    /// Internal Memo, unlimited length
    /// </summary>
    public string Memo   
    { 
      get => _Memo ;
      set => Set(value, ref _Memo); 
    }

    private bool? _Strikebound;
    /// <summary>
    /// A strikebound Flight is not operating because the Pilot and/or other Employees are refusing to work.
    /// </summary>
    public bool? Strikebound   
    { 
      get => _Strikebound ;
      set => Set(value, ref _Strikebound); 
    }

    private int? _Utilization;
    /// <summary>
    /// FreeSeats / Seats (calculated in DBMS)
    /// </summary>
    public int? Utilization   
    { 
      get => _Utilization ;
      set => Set(value, ref _Utilization); 
    }

    private byte[] _Timestamp;
    /// <summary>
    /// Rowversion for Concurrecy Check
    /// </summary>
    public byte[] Timestamp   
    { 
      get => _Timestamp ;
      set => Set(value, ref _Timestamp); 
    }

    private Pilot _Pilot_Person ;

    public Pilot Pilot_Person
    { 
      get => _Pilot_Person ;
      set => Set(value, ref _Pilot_Person); 
    }  


    public virtual ObservableCollection<Passenger> Passenger_Person { get; } = new ObservableCollection<Passenger>();
}
