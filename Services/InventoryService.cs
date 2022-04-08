using InventoryCoding.WebAPI.Abstractions;
using InventoryCoding.WebAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;
using static InventoryCoding.WebAPI.Models.InventoryDTO;

namespace InventoryCoding.WebAPI.Services
{
    public class InventoryService : IInventoryService
    {

        string mockApiUrl = "https://mocki.io/v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60";
        public async Task<Inventory> GetInventory(int? requestedInventory)
        {
            RestClient Client = new RestClient();
            var request = new RestRequest(mockApiUrl, Method.Get);
            var exeresult = await Client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<InventoryDTO>(exeresult.get_Content()).inventory.Find(x => x.id == requestedInventory);
        }
        public async Task<Request> GetRequests(int requestedKernals)
        {
            RestClient Client = new RestClient();
            var request = new RestRequest(mockApiUrl, Method.Get);
            var exeresult = await Client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<InventoryDTO>(exeresult.get_Content()).requests.Find(x => x.requestedKernels == requestedKernals);
        }

        public async Task<InventoryDTO> GetTotalInventory()
        {
            RestClient Client = new RestClient();
            var request = new RestRequest(mockApiUrl, Method.Get);
            var exeresult = await Client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<InventoryDTO>(exeresult.get_Content());
        }

        public async Task<bool> CheckAvailabelKernals(int inventoryId, int requestedKernals)
        {
            InventoryDTO inventoryResponse = await GetTotalInventory();
            if (inventoryResponse != null)
            {
                int? totalKernalsAvailable = inventoryResponse?.inventory?.Where(x => x.id == inventoryId).FirstOrDefault().kernels - requestedKernals;
                int? requestedInventory = inventoryResponse?.requests?.Where(x => x.id == inventoryId)
                        .GroupBy(x => inventoryId)
                        .Select(x => x.Sum(a => a.requestedKernels)).Sum();
                int res = totalKernalsAvailable.Value - requestedInventory.Value;
                if (res > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
