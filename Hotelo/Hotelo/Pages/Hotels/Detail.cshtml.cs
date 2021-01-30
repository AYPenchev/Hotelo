using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hotelo.Core;
using Hotelo.Data;

namespace Hotelo.Pages.Hotels
{
    public class DetailModel : PageModel
    {
        private readonly IHotelData _HotelData;

        [TempData]
        public string Message { get; set; }
        public Hotel Hotel { get; set; }

        public DetailModel(IHotelData HotelData)
        {
            this._HotelData = HotelData;
        }

        public IActionResult OnGet(int HotelId)
        {
            Hotel = this._HotelData.GetById(HotelId);
            if (Hotel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}