using System;
using System.Collections.ObjectModel;

// Entitaetsklasse mit Basisklasse BOBase mit INotifyPropertyChanging & INotifyPropertyChanged 
// Autor der T4-Vorlage: Dr. Holger Schwichtenberg, 8.9.2022
// Generiert mit EF Core 7.0.0 am 12/05/2022 21:11:33 von ITV/HS
namespace BO;

/// <summary>
/// An Airport with is Geo-Coordinate (WGS 84, SRID 4326)
/// </summary>
public partial class Airport : BOBase
{
    private string _Name;
    public string Name   
    { 
      get => _Name ;
      set => Set(value, ref _Name); 
    }

    private int? _Typ;
    public int? Typ   
    { 
      get => _Typ ;
      set => Set(value, ref _Typ); 
    }
}
