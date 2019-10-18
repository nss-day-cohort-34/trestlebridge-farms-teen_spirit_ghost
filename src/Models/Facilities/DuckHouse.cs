using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<IGrazing>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _ducks = new List<IGrazing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IGrazing duck)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public void AddResource (List<IGrazing> ducks)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} ducks\n");
            this._ducks.ForEach(d => output.Append($"   {d}\n"));

            return output.ToString();
        }
    }
}