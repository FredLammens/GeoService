using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class River
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();
    }
}
