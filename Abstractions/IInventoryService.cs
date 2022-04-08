using InventoryCoding.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InventoryCoding.WebAPI.Models.InventoryDTO;

namespace InventoryCoding.WebAPI.Abstractions
{
    public interface IInventoryService
    {

        Task<Inventory> GetInventory(int? requestedInventory);
        Task<Request> GetRequests(int requestedKernals);
        Task<InventoryDTO> GetTotalInventory();
        Task<bool> CheckAvailabelKernals(int inventoryId , int requestedKernals);


    }
}
