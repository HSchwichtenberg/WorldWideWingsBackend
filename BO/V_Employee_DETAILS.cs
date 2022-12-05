using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

public partial class V_Employee_DETAILS : BOBase
{
    private int _PersonID;
    public int PersonID   
    { 
      get => _PersonID ;
      set => Set(value, ref _PersonID); 
    }

    private DateTime? _HireDate;
    public DateTime? HireDate   
    { 
      get => _HireDate ;
      set => Set(value, ref _HireDate); 
    }

    private int? _EmployeeNo;
    public int? EmployeeNo   
    { 
      get => _EmployeeNo ;
      set => Set(value, ref _EmployeeNo); 
    }

    private int? _Supervisor_PersonID;
    public int? Supervisor_PersonID   
    { 
      get => _Supervisor_PersonID ;
      set => Set(value, ref _Supervisor_PersonID); 
    }

    private string _SurName;
    public string SurName   
    { 
      get => _SurName ;
      set => Set(value, ref _SurName); 
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
}
