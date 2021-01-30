using System.Collections.Generic;
using System.Linq;
using Hotelo.Core;

namespace Hotelo.Data
{
    public class InMemoryHotelData : IHotelData
    {
        private readonly List<Hotel> _Hotels;

        public InMemoryHotelData()
        {
            _Hotels = new List<Hotel>()
            {
                new Hotel { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Hotel { Id = 2, Name = "Matew's Pizza", Location = "Bulgaria", Cuisine = CuisineType.Mexican },
                new Hotel { Id = 3, Name = "Ivan's Pizza", Location = "France", Cuisine = CuisineType.Indian }
            };
        }

        public Hotel Add(Hotel newHotel)
        {
            _Hotels.Add(newHotel);
            newHotel.Id = _Hotels.Max(r => r.Id) + 1;
            return newHotel;
        }

        public int Commit()
        {
            return 0;
        }

        public Hotel Delete(int id)
        {
            var Hotel = _Hotels.FirstOrDefault(r => r.Id == id);
            if (Hotel != null)
            {
                _Hotels.Remove(Hotel);
            }

            return Hotel;
        }

        public Hotel GetById(int id)
        {
            return _Hotels.SingleOrDefault(Hotel => Hotel.Id == id);
        }

        public int GetCountOfHotels()
        {
            return _Hotels.Count();
        }

        public IEnumerable<Hotel> GetHotelsByName(string name = null)
        {
            return from Hotel in _Hotels
                   where string.IsNullOrEmpty(name) || Hotel.Name.StartsWith(name)
                orderby Hotel.Name
                select Hotel;
        }

        public Hotel Update(Hotel updatedHotel)
        {
            var Hotel = _Hotels.SingleOrDefault(r => r.Id == updatedHotel.Id);
            if (Hotel != null)
            {
                Hotel.Name = updatedHotel.Name;
                Hotel.Location = updatedHotel.Location;
                Hotel.Cuisine = updatedHotel.Cuisine;
            }

            return Hotel;
        }
    }
}