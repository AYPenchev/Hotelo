using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Hotelo.Core;
using Hotelo.Data;

namespace Hotelo.Pages.Hotels
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IHotelData _HotelData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public  IEnumerable<Hotel> Hotels { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IHotelData HotelData, ILogger<ListModel> logger)
        {
            this._config= config;
            this._HotelData = HotelData;
            this._logger = logger;
        }
        
        public void OnGet()
        {
            Message = this._config["Message"];
            Hotels = this._HotelData.GetHotelsByName(SearchTerm);
        }
    }
}