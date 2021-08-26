using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITexusTaskOne.Models
{
    public class Wagon
    {
        public int WagonID { get; set; }
        public string InventoryNum { get; set; }
        public string Model { get; set; }

        public DateTime ProdDate { get; set; }

        public DateTime ExpDate { get; set; }

        public float WagWeight { get; set; }

        public Wagon()
        {

        }       
    }
}
