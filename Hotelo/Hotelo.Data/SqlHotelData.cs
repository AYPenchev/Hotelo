using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Hotelo.Core;

namespace Hotelo.Data
{
    public class SqlHotelData : IHotelData
    {
        private readonly HoteloDbContext _db;

        public SqlHotelData(HoteloDbContext db)
        {
            this._db = db;
        }
        public Hotel Add(Hotel newHotel)
        {
            this._db.Hotels.Add(newHotel);
            return newHotel;
        }

        public int Commit()
        {
            return this._db.SaveChanges();
        }

        public Hotel Delete(int id)
        {
            var Hotel = GetById(id);
            if (Hotel != null)
            {
                this._db.Hotels.Remove(Hotel);
            }

            return Hotel;
        }

        public Hotel GetById(int id)
        {
            return this._db.Hotels.Find(id);
        }

        public int GetCountOfHotels()
        {
            return this._db.Hotels.Count();
        }

        public IEnumerable<Hotel> GetHotelsByName(string name)
        {
            return from r in this._db.Hotels
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public Hotel Update(Hotel updatedHotel)
        {
            var entity = this._db.Hotels.Attach(updatedHotel);
            entity.State = EntityState.Modified;
            return updatedHotel;
        }
    }
}