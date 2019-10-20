using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
  public class ChoosePlantField
  {
    // >> BEGIN SUCCESS MESSAGE HANDLING
    public static void ResourceAddedMessage(string resource, string field)
    {
      Console.WriteLine();
      Console.WriteLine($"New {resource} Added to the {field} Field!");
      Farm.PauseForMessage();
    }

    public static void ReturnToMainMessage()
    {
      Console.WriteLine();
      Console.Write($"Press 'Enter' to Return To Main >> ");
      string Input = Console.ReadLine();
      if (Input != "") ReturnToMainMessage();
    }
    // >> END SUCCESS MESSAGE HANDLING

    public static void CollectInput(Farm farm, IResource plant)
    {
      Console.Clear();

      // Evaluate type of plant and add resource to proper Planting Field
      var plantType = plant.GetType();
      bool isCompostProducingType = plantType.GetInterfaces().Contains(typeof(ICompostProducing));
      bool isSeedProducingType = plantType.GetInterfaces().Contains(typeof(ISeedProducing));

      // RETURN ONLY FIELDS WITH SPACE AVAILABLE (where plantcount < capacity)
      var plowedAvailable = farm.PlowedFields.Where(field => field.Capacity > field.PlantCount).ToList();
      var naturalAvailable = farm.NaturalFields.Where(field => field.Capacity > field.PlantCount).ToList();


      // BEGIN SELECTION PROCESS

      if (isSeedProducingType && isCompostProducingType)
      {
        // WHEN NO FIELDS AVAILABLE
        if (plowedAvailable.Count == 0 && naturalAvailable.Count == 0)
        {
          Console.WriteLine("!! NO FIELDS AVAILBLE !!");
          ReturnToMainMessage();
        }
        // WHEN FIELDS ARE AVAILABLE
        else
        {

          if (plowedAvailable.Count > 0) Console.WriteLine("For Seed");

          for (int i = 0; i < plowedAvailable.Count; i++)
          {
            int currentCount = plowedAvailable[i].PlantCount;
            string plantTotal = plowedAvailable[i].PlantTotal;

            Console.WriteLine($"  {i + 1}. Plowed Field ({currentCount} row{farm.Pluralize(currentCount)} of plants{plantTotal})");
          }

          if (naturalAvailable.Count > 0) Console.WriteLine("For Compost");

          for (int i = plowedAvailable.Count; i < naturalAvailable.Count + plowedAvailable.Count; i++)
          {
            int currentCount = naturalAvailable[i - plowedAvailable.Count].PlantCount;
            string plantTotal = naturalAvailable[i - plowedAvailable.Count].PlantTotal;
            Console.WriteLine($"  {i + 1}. Natural Field ({currentCount} row{farm.Pluralize(currentCount)} of plants{plantTotal})");
          }
          Console.WriteLine();
          Console.WriteLine($"Place the {plantType.Name} where?");
          Console.Write("> ");

          int choiceInput = Int32.Parse(Console.ReadLine());
          int choice = choiceInput - 1;

          if (choice < plowedAvailable.Count)
          {
            plowedAvailable[choice].AddResource((ISeedProducing)plant);
            ResourceAddedMessage(plantType.Name, "Plowed");
          }
          else
          {
            naturalAvailable[choice - plowedAvailable.Count].AddResource((ICompostProducing)plant);
            ResourceAddedMessage(plantType.Name, "Natural");
          }
        }
      }
      else if (isSeedProducingType)
      {
        // WHEN NO FIELDS AVAILABLE
        if (plowedAvailable.Count == 0)
        {
          Console.WriteLine("!! NO FIELDS AVAILBLE !!");
          ReturnToMainMessage();
        }
        // WHEN FIELDS ARE AVAILABLE
        else
        {
          Console.WriteLine("For Seed");
          for (int i = 0; i < plowedAvailable.Count; i++)
          {
            int currentCount = plowedAvailable[i].PlantCount;
            string plantTotal = plowedAvailable[i].PlantTotal;
            Console.WriteLine($"  {i + 1}. Plowed Field ({currentCount} row{farm.Pluralize(currentCount)} of plants{plantTotal})");
          }
          Console.WriteLine();
          Console.WriteLine($"Place the {plantType.Name} where?");
          Console.Write("> ");

          int choiceInput = Int32.Parse(Console.ReadLine());
          int choice = choiceInput - 1;

          plowedAvailable[choice].AddResource((ISeedProducing)plant);
          ResourceAddedMessage(plantType.Name, "Plowed");
        }
      }
      else if (isCompostProducingType)
      {
        // WHEN NO FIELDS AVAILABLE
        if (naturalAvailable.Count == 0)
        {
          Console.WriteLine("!! NO FIELDS AVAILBLE !!");
          ReturnToMainMessage();
        }
        // WHEN FIELDS ARE AVAILABLE
        else
        {
          Console.WriteLine("For Compost");
          for (int i = 0; i < naturalAvailable.Count; i++)
          {
            int currentCount = naturalAvailable[i].PlantCount;
            string plantTotal = naturalAvailable[i].PlantTotal;
            Console.WriteLine($"  {i + 1}. Natural Field  ({currentCount} row{farm.Pluralize(currentCount)} of plants{plantTotal})");
          }
          Console.WriteLine();
          Console.WriteLine($"Place the {plantType.Name} where?");
          Console.Write("> ");

          int choiceInput = Int32.Parse(Console.ReadLine());
          int choice = choiceInput - 1;

          naturalAvailable[choice].AddResource((ICompostProducing)plant);
          ResourceAddedMessage(plantType.Name, "Natural");
        }
      }
    }
  }
}
