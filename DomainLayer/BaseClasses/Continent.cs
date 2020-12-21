using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLayer.BaseClasses
{
    class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get => Population; private set {
                if (_countries.Count > 0)
                {
                    _countries.ForEach(countrie => Population += countrie.Population);
                }
                else
                    Population = 0;
           } 
        }
        private List<Country> _countries = new List<Country>();
        public IReadOnlyList<Country> Countries { get => _countries.AsReadOnly();}
    }
}
