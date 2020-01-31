using System.Threading.Tasks;
using RMWPFUI.Models;

namespace RMWPFUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}