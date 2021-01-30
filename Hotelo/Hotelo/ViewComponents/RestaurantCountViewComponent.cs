using Microsoft.AspNetCore.Mvc;
using Hotelo.Data;

namespace Hotelo.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = this._restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
