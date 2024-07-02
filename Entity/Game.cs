using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Entity
{
    public class Game
    {  public Guid Id{get;set;}
        public string? Name { get; set; } 

        public string Genre {get;set;} =string.Empty;

        public decimal Price {get;set;}

        public DateTime ReleaseDate {get;set;}
        
    }
}