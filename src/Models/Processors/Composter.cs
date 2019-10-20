using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Processors
{
  public class Composter
  {
    public void Process(ICompostProducing resource)
    {
      // ! refactor interface back to simply 'Harvest' and then use override
      resource.HarvestCompost();
    }
  }
}