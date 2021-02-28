using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Services.MVCManagement
{
    public interface IMVCManager
    {
        Task<string> RenderViewToString(Controller controller, object model, string viewName = null, bool partial = true);
    }
}
