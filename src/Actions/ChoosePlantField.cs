using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using System.Linq;

namespace Trestlebridge.Actions
{
  public class ChoosePlantField
  {
    public static void CollectInput(Farm farm, IResource plant)
    {
      Console.Clear();
      // evaluate type of plant and then add resource to proper field
      var plantType = plant.GetType();

      bool isCompostProducingType = plantType.GetInterfaces().Contains(typeof(ICompostProducing));
      bool isSeedProducingType = plantType.GetInterfaces().Contains(typeof(ISeedProducing));

      int plowedFieldCount = farm.PlowedFields.Count;
      int naturalFieldCount = farm.NaturalFields.Count;

      Console.WriteLine($"Field Options:");

      if (isSeedProducingType && isCompostProducingType)
      {
        if (plowedFieldCount > 0) Console.WriteLine("For Seed");

        for (int i = 0; i < plowedFieldCount; i++)
        {
          Console.WriteLine($"  {i + 1}. Plowed Field");
        }

        if (naturalFieldCount > 0) Console.WriteLine("For Compost");

        for (int i = plowedFieldCount; i < naturalFieldCount + plowedFieldCount; i++)
        {
          Console.WriteLine($"  {i + 1}. Natural Field");
        }
        Console.WriteLine();
        Console.WriteLine($"Place the {plantType.Name} where?");
        Console.Write("> ");

        int choiceInput = Int32.Parse(Console.ReadLine());
        int choice = choiceInput - 1;

        if (choice < plowedFieldCount)
        {
          farm.PlowedFields[choice].AddResource((ISeedProducing)plant);
        }
        else
        {
          farm.NaturalFields[choice - plowedFieldCount].AddResource((ICompostProducing)plant);
        }
      }
      else if (isSeedProducingType)
      {
        Console.WriteLine("For Seed");
        for (int i = 0; i < plowedFieldCount; i++)
        {
          Console.WriteLine($"  {i + 1}. Plowed Field");
        }
        Console.WriteLine();
        Console.WriteLine($"Place the {plantType.Name} where?");
        Console.Write("> ");

        int choiceInput = Int32.Parse(Console.ReadLine());
        int choice = choiceInput - 1;

        farm.PlowedFields[choice].AddResource((ISeedProducing)plant);
      }
      else if (isCompostProducingType)
      {
        Console.WriteLine("For Compost");
        for (int i = 0; i < naturalFieldCount; i++)
        {
          Console.WriteLine($"  {i + 1}. Natural Field");
        }
        Console.WriteLine();
        Console.WriteLine($"Place the {plantType.Name} where?");
        Console.Write("> ");

        int choiceInput = Int32.Parse(Console.ReadLine());
        int choice = choiceInput - 1;

        farm.NaturalFields[choice].AddResource((ICompostProducing)plant);
      }
    }
  }
}