using Microsoft.AspNetCore.Mvc;
using Services.VendorItemManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class VendorItemController : Controller
    {
        private readonly IVendorItemManager _vendorItemManager;
        public VendorItemController(IVendorItemManager vendorItemManager)
        {
            _vendorItemManager = vendorItemManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var vendorItems = await _vendorItemManager.LoadVendorItems();
                return View(vendorItems);
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
