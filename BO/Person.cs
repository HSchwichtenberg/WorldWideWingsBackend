using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// Basic Data of a Person (Person is abstract, used as Passenger, Employee or Pilot)
/// </summary>
public partial class Person : BOBase
{
    private int _PersonID;
    public int PersonID   
    { 
      get => _PersonID ;
      set => Set(value, ref _PersonID); 
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

    private string _City;
    public string City   
    { 
      get => _City ;
      set => Set(value, ref _City); 
    }

    private string _Memo;
    public string Memo   
    { 
      get => _Memo ;
      set => Set(value, ref _Memo); 
    }

    private string _Planet;
    public string Planet   
    { 
      get => _Planet ;
      set => Set(value, ref _Planet); 
    }

    private string _Sternensystem;
    public string Sternensystem   
    { 
      get => _Sternensystem ;
      set => Set(value, ref _Sternensystem); 
    }

    private Employee _Employee ;

    public Employee Employee
    { 
      get => _Employee ;
      set => Set(value, ref _Employee); 
    }  


    private Passenger _Passenger ;

    public Passenger Passenger
    { 
      get => _Passenger ;
      set => Set(value, ref _Passenger); 
    }  

}
