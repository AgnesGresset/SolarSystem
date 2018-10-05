using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonnensystem
{
    class Planet : SolarSystemInterface
    {
        private string Name { get; set; }
        Satellite satellite = new Satellite();

        public Planet()
        {
        }

        public Planet(string name)
        {
            Name = name;
        }

        public Planet(string name, Satellite satellite)
        {
            Name = name;
            this.satellite = satellite;
        }

        public void sortPlanets()
        {
            // GetAllPlanets and sort them here.
        }
    }
}
