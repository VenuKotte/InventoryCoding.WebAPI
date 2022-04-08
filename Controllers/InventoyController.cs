using System.Threading.Tasks;
using InventoryCoding.WebAPI.Abstractions;
using InventoryCoding.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryCoding.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoyController : ControllerBase
    {
           private readonly IInventoryService _inventoryService;
        public InventoyController(IInventoryService inventoryService)
        {
            this._inventoryService = inventoryService;
        }
       

        [Route("getTotalInventory")]
        [HttpGet]
        public async Task<InventoryDTO> GetTotalInventoryInfo()
        {
            return  await _inventoryService.GetTotalInventory();
        }

        [Route("checkAvailableKernals/{inventoryId}/{requestedkernals}")]
        [HttpGet]
        public async Task<bool> CheckAvailabelKernals(int inventoryId , int requestedKernals)
        {
               return await _inventoryService.CheckAvailabelKernals(inventoryId,requestedKernals);
        }

    }
}