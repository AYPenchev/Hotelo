using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hotelo.Core;
using Hotelo.Data;

namespace Hotelo.Pages.Hotels
{
    public class DeleteModel : PageModel
    {
        private readonly IHotelData _HotelData;

        public Hotel Hotel { get; set; }

        public DeleteModel(IHotelData HotelData)
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

        public IActionResult OnPost(int HotelId)
        {
            var Hotel = this._HotelData.Delete(HotelId);
            this._HotelData.Commit();

            if (Hotel == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{Hotel.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}