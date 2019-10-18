using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
  public class Farm
  {
    public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
    public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();

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

    public void AddGrazingField(GrazingField field)
    {
      GrazingFields.Add(field);
    }
    public void AddPlowedField(PlowedField field)
    {
      PlowedFields.Add(field);
      Console.WriteLine();
      Console.WriteLine($"New Plowed Field Added!");
      System.Threading.Thread.Sleep(3000);

    }

    public override string ToString()
    {
      StringBuilder report = new StringBuilder();

      GrazingFields.ForEach(gf => report.Append(gf));
      PlowedFields.ForEach(pf => report.Append(pf));

      return report.ToString();
    }
  }
}