using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotels.Models
{
    public class Hotel
    {
        private int _id;
        private string _name;
        private int _availableRooms;
        private string _address;
        private string _cityCode;
        
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int AvailableRooms { get => _availableRooms; set => _availableRooms = value; }
        public string Address { get => _address; set => _address = value; }
        public string CityCode { get => _cityCode; set => _cityCode = value; }

        public Hotel(Hotel hotel)
        {
            this.Id = hotel.Id;
            this.Name = hotel.Name;
            this._address = hotel.Address;
            this.AvailableRooms = AvailableRooms;
            this.CityCode = CityCode;
        }
        public Hotel() { }
    }
}