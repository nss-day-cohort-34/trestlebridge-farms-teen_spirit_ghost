using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
  public class Sesame : IResource, ISeedProducing
  {
    private int _seedsProduced = 40;
    public string Type { get; } = "Sesame";

    public double HarvestSeed()
    {
      return _seedsProduced;
    }

    public double Seed()
    {
      return _seedsProduced;
    }

    public override string ToString()
    {
      return $"Sesame. Yum!";
    }
  }
}