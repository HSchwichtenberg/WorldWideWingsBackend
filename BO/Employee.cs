using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// An Employee is a specialization of a Person.
/// </summary>
public partial class Employee : BOBase
{
    private int _PersonID;
    public int PersonID   
    { 
      get => _PersonID ;
      set => Set(value, ref _PersonID); 
    }

    private int? _EmployeeNo;
    public int? EmployeeNo   
    { 
      get => _EmployeeNo ;
      set => Set(value, ref _EmployeeNo); 
    }

    private DateTime? _HireDate;
    public DateTime? HireDate   
    { 
      get => _HireDate ;
      set => Set(value, ref _HireDate); 
    }

    private int? _Supervisor_PersonID;
    public int? Supervisor_PersonID   
    { 
      get => _Supervisor_PersonID ;
      set => Set(value, ref _Supervisor_PersonID); 
    }

    public virtual ObservableCollection<Employee> InverseSupervisor_Person { get; } = new ObservableCollection<Employee>();

    private Person _Person ;

    public Person Person
    { 
      get => _Person ;
      set => Set(value, ref _Person); 
    }  


    private Pilot _Pilot ;

    public Pilot Pilot
    { 
      get => _Pilot ;
      set => Set(value, ref _Pilot); 
    }  


    private Employee _Supervisor_Person ;

    public Employee Supervisor_Person
    { 
      get => _Supervisor_Person ;
      set => Set(value, ref _Supervisor_Person); 
    }  

}
