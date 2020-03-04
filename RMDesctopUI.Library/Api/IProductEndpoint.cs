using System.Collections.Generic;
using System.Threading.Tasks;
using RMDesctopUI.Library.Models;

namespace RMDesctopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}