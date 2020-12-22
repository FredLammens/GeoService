using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.BaseClasses
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public Country BelongsTo { get; set; }
        public Country CapitalFrom { get; set; }
    }
}
