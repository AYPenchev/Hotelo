using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Hotelo.Core;
using Hotelo.Data;

namespace Hotelo.Pages.Hotels
{
    public class DownloadModel : PageModel
    {
        private readonly IHotelData _HotelData;
        public Hotel Hotel { get; set; }

        public DownloadModel(IHotelData HotelData)
        {
            _HotelData = HotelData;
        }
        public void OnGet(int HotelId)
        {
            Hotel = this._HotelData.GetById(HotelId);

            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            serializer.Serialize(System.IO.File.Create($"{Hotel.Name}_{HotelId}.xml"), Hotel);
        }
    }
}