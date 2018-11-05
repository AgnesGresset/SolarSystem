using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemDraft
{
    class Planet : SolarSystemInterface
    {
        private string Name { get; set; }
        public List<Satellite> Satellites { get; set; }

        public Planet()
        {
        }

        public Planet(string name)
        {
            Name = name;
        }

        public Planet(string name, List<Satellite> satellites)
        {
            Name = name;
            Satellites = satellites;
        }

        public void sortPlanets()
        {
            // GetAllPlanets and sort them here.
        }
    }
}
