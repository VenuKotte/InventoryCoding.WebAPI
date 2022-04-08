using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryCoding.WebAPI.Models
{
    public class InventoryDTO
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Inventory
        {
            public int id { get; set; }
            public string name { get; set; }
            public int kernels { get; set; }
        }

        public class Request
        {
            public int id { get; set; }
            public string inventoryId { get; set; }
            public int requestedKernels { get; set; }
        }

  
            public List<Inventory> inventory { get; set; }
            public List<Request> requests { get; set; }
        


    }
}
