using System;
using System.Collections.Generic;
using System.Text;

namespace Busquedas
{
    public class Rute
    {
        public City DestinationCity { get; set; }
        public int Cost { get; set; }

        public Rute(City destination, int cost)
        {
            this.DestinationCity = destination;
            this.Cost = cost;
        }
    }

}
