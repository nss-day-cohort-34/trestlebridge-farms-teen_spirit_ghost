using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;
using System.Threading;

namespace Trestlebridge.Models
{
  public class Farm
  {
    public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
    public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();
    public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
    public List<DuckHouse> DuckHouses { get; } = new List<DuckHouse>();
    // public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();

    /*
        This method must specify the correct product interface of the
        resource being purchased.
     */

    public void PurchaseResource<T>(IResource resource, int index)
    {

      Console.WriteLine(typeof(T).ToString());
      switch (typeof(T).ToString())
      {
        case "Cow":
          GrazingFields[index].AddResource((IGrazing)resource);
          break;
        case "Sesame":
          PlowedFields[index].AddResource((ISeedProducing)resource);
          break;
        default:
          break;
      }
    }

    public void PauseForMessage()
    {
      Thread.Sleep(2000);
    }
    public void AddPlowedField(PlowedField field)
    {
      PlowedFields.Add(field);
      Console.WriteLine();
      Console.WriteLine($"New Plowed Field Added!");
      PauseForMessage();

    }
    public void AddNaturalField(NaturalField field)
    {
      NaturalFields.Add(field);
      Console.WriteLine();
      Console.WriteLine($"New Natural Field Added!");
      PauseForMessage();
    }

    public void AddGrazingField(GrazingField field)
    {
      GrazingFields.Add(field);
    }
    public void AddDuckHouse(DuckHouse house)
    {
      DuckHouses.Add(house);
    }


    public override string ToString()
    {
      StringBuilder report = new StringBuilder();

      DuckHouses.ForEach(dh => report.Append(dh));
      GrazingFields.ForEach(gf => report.Append(gf));
      PlowedFields.ForEach(pf => report.Append(pf));
      NaturalFields.ForEach(nf => report.Append(nf));

      return report.ToString();
    }
  }
}