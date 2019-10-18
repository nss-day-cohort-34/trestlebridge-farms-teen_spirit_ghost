using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
  public class Wildflower : IResource, ICompostProducing
  {
    private int _compostProduced = 40;
    public string Type { get; } = "Wildflower";

    public double HarvestCompost()
    {
      return _compostProduced;
    }

    public override string ToString()
    {
      return $"Wildflower. Yum!";
    }
  }
}