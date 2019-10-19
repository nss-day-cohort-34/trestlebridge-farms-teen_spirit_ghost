using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
  public class NaturalField : IFacility<ICompostProducing>
  {
    private int _capacity = 4; // set back to 10 after testing
    private Guid _id = Guid.NewGuid();


    public int PlantCount { get { return _plants.Count; } }
    private List<ICompostProducing> _plants = new List<ICompostProducing>();

    public double Capacity
    {
      get
      {
        return _capacity;
      }
    }

    public void AddResource(ICompostProducing plant)
    {
      _plants.Add(plant);

    }

    public void AddResource(List<ICompostProducing> plants)
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
      output.Append($"Natural field {shortId} has {this._plants.Count} plant{plural}\n");
      this._plants.ForEach(a => output.Append($"   {a}\n"));

      return output.ToString();
    }
  }
}