using RMDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);

        Task GetLogedInUserInfo(string token);

        HttpClient ApiClient { get; }
    }
}