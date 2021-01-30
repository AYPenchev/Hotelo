using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotelo.Core;
using Hotelo.Data;

namespace Hotelo.Pages.Hotels
{
    public class EditModel : PageModel
    {
        private readonly IHotelData _HotelData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Hotel Hotel { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IHotelData HotelData, IHtmlHelper htmlHelper)
        {
            this._HotelData = HotelData;
            this._htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? HotelId)
        {
            Cuisines = this._htmlHelper.GetEnumSelectList<CuisineType>();

            if (HotelId.HasValue)
            {
                Hotel = this._HotelData.GetById(HotelId.Value);
            }
            else
            {
                Hotel = new Hotel();
            }

            if (Hotel == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = this._htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Hotel.Id > 0)
            {
                this._HotelData.Update(Hotel);
            }
            else
            {
                this._HotelData.Add(Hotel);
            }
            this._HotelData.Commit();
            TempData["Message"] = "Hotel saved!";
            return RedirectToPage("./Detail", new { HotelId = Hotel.Id });
        }
    }
}