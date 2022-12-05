using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

public partial class V_Passenger_DETAILS : BOBase
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

    private string _Surname;
    public string Surname   
    { 
      get => _Surname ;
      set => Set(value, ref _Surname); 
    }

    private string _GivenName;
    public string GivenName   
    { 
      get => _GivenName ;
      set => Set(value, ref _GivenName); 
    }

    private string _Country;
    public string Country   
    { 
      get => _Country ;
      set => Set(value, ref _Country); 
    }

    private DateTime? _Birthday;
    public DateTime? Birthday   
    { 
      get => _Birthday ;
      set => Set(value, ref _Birthday); 
    }

    private byte[] _Photo;
    public byte[] Photo   
    { 
      get => _Photo ;
      set => Set(value, ref _Photo); 
    }

    private string _EMail;
    public string EMail   
    { 
      get => _EMail ;
      set => Set(value, ref _EMail); 
    }

    private string _Fullname;
    public string Fullname   
    { 
      get => _Fullname ;
      set => Set(value, ref _Fullname); 
    }
}
