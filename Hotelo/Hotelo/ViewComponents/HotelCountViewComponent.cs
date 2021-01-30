using Microsoft.AspNetCore.Mvc;
using Hotelo.Data;

namespace Hotelo.ViewComponents
{
    public class HotelCountViewComponent : ViewComponent
    {
        private readonly IHotelData _HotelData;

        public HotelCountViewComponent(IHotelData HotelData)
        {
            this._HotelData = HotelData;
        }

        public IViewComponentResult Invoke()
        {
            var count = this._HotelData.GetCountOfHotels();
            return View(count);
        }
    }
}
