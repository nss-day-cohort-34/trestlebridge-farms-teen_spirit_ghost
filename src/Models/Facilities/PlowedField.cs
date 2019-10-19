using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
  public class PlowedField : IFacility<ISeedProducing>
  {
    private int _capacity = 3; // set back to 13 after testing
    private Guid _id = Guid.NewGuid();

    private List<ISeedProducing> _plants = new List<ISeedProducing>();

    public int PlantCount { get { return _plants.Count; } }

    public double Capacity
    {
      get
      {
        return _capacity;
      }
    }

    public void AddResource(ISeedProducing plant)
    {
      _plants.Add(plant);

    }

    public void AddResource(List<ISeedProducing> plants)
    {
      // TODO: implement this...
      throw new NotImplementedException();

    }


    public override string ToString()
    {
      StringBuilder output = new StringBuilder();
      string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";
      string plural = "s";
      if (this._plants.Count == 1) plural = "";
      output.Append($"Plowed field {shortId} has {this._plants.Count} plant{plural}\n");
      this._plants.ForEach(a => output.Append($"   {a}\n"));

      return output.ToString();
    }
  }
}