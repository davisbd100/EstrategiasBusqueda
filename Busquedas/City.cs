using System;
using System.Collections.Generic;
using System.Text;

namespace Busquedas
{
    public class City
    {
        public String CityName { get; set; }
        public List<Rute> Rutes { get; set; }
        public int PathCost { get; set; }

        public City(String name)
        {
            this.CityName = name;
        }
    }
}
