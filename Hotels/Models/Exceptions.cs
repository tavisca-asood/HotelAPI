using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotels.Models
{
    public class IDNotFoundException : Exception
    {
        public IDNotFoundException(int id) : base(String.Format("Id {0} not found!", id))
        { }

    }

    public class NotEnoughRoomsException:Exception
    {
        public NotEnoughRoomsException() : base("Sorry! Not enough rooms available.") { }
    }

    public class InvalidHotelObjectException:Exception
    {
        public InvalidHotelObjectException() : base("You have not sent a valid hotel object!") { }
    }
}