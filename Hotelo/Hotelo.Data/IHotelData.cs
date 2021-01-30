using Hotelo.Core;
using System.Collections.Generic;

namespace Hotelo.Data
{
    public interface IHotelData
    {
        IEnumerable<Hotel> GetHotelsByName(string name);
        Hotel GetById(int id);
        Hotel Update(Hotel updatedHotel);
        Hotel Add(Hotel newHotel);
        Hotel Delete(int id);
        int GetCountOfHotels();
        int Commit();
    }
}
