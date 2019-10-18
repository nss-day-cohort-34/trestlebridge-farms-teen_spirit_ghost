using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
  public class Sunflower : IResource, ICompostProducing, ISeedProducing
  {
    private int _seedsProduced = 40;
    private int _compostProduced = 40;
    public string Type { get; } = "Sunflower";

    public double HarvestCompost()
    {
      return _compostProduced;
    }

    public double HarvestSeed()
    {
      return _seedsProduced;
    }

    public override string ToString()
    {
      return $"Sunflower. Yum!";
    }
  }
}