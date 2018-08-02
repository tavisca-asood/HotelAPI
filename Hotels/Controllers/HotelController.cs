using Hotels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotels.Controllers
{
    public class HotelController : ApiController
    {
        private static int _counter = 4;
        private static List<Hotel> hotels = new List<Hotel>()
        {
            new Hotel(){Name="Ibis", Address="Survey No 32, Viman Nagar Rd",AvailableRooms=10,CityCode="PNQ",Id=1},
            new Hotel(){Name="JW Marriott",Address="",AvailableRooms=23,CityCode="IXC",Id=2},
            new Hotel(){Name="Novotel",Address=" Weikfield IT City Infopark Survey No 30/3",AvailableRooms=15,CityCode="PNQ",Id=3}
        };

        // GET: api/Hotel
        public ApiResponse Get()
        {
            try
            {
                return new ApiResponse()
                {
                    hotelsResponse = hotels,
                    status = new Status()
                    {
                        ApiStatus = ApiStatus.Success,
                        StatusCode = 200,
                        StatusMessage = "Success!"
                    }
                };
            }
            catch (Exception exception)
            {
                return new ApiResponse()
                {
                    hotelsResponse = null,
                    status = new Status()
                    {
                        ApiStatus = ApiStatus.Failiure,
                        StatusCode = 500,
                        StatusMessage = "Internal Server Error!"
                    }
                };
            }
        }

        // GET: api/Hotel/5
        public ApiResponse Get(int id)
        {
            try
            {
                Hotel hotel = hotels.Find(x => x.Id == id);
                if (hotel == null)
                {
                    throw new IDNotFoundException(id);
                }
                return new ApiResponse()
                {
                    hotelsResponse = new List<Hotel>()
                    {
                        new Hotel(hotel)
                    }
                    ,
                    status = new Status()
                    {
                        StatusMessage = "ID Found!",
                        StatusCode = 200,
                        ApiStatus = ApiStatus.Success
                    }
                };
            }
            catch (IDNotFoundException exception)
            {
                return new ApiResponse()
                {
                    hotelsResponse = null,
                    status = new Status()
                    {
                        StatusMessage = exception.Message,
                        StatusCode = 404,
                        ApiStatus = ApiStatus.NotFound
                    }
                };
            }
            catch (Exception exception)
            {
                return new ApiResponse()
                {
                    hotelsResponse = null,
                    status = new Status()
                    {
                        StatusMessage = exception.Message,
                        StatusCode = 500,
                        ApiStatus = ApiStatus.Failiure
                    }
                };
            }
        }

        // POST: api/Hotel
        public Status Post(Hotel hotel)
        {
            try
            {
                if (hotel == null)
                    throw new InvalidHotelObjectException();
                hotel.Id = _counter++;
                hotels.Add(hotel);
                return new Status()
                {
                    ApiStatus = ApiStatus.Success,
                    StatusCode = 200,
                    StatusMessage = "Hotel added!"
                };
            }
            catch(InvalidHotelObjectException exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.Failiure,
                    StatusCode = 400,
                    StatusMessage = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.Failiure,
                    StatusCode = 500,
                    StatusMessage = "Internal Server Error!"
                };
            }
        }

        // PUT: api/Hotel/5
        public Status Put(int id, [FromBody]int noOfRooms)
        {
            try
            {
                Hotel hotel = hotels.Find(x => x.Id == id);
                if (hotel == null)
                {
                    throw new IDNotFoundException(id);
                }
                if (hotel.AvailableRooms < noOfRooms)
                {
                    throw new NotEnoughRoomsException();
                }
                hotel.AvailableRooms = hotel.AvailableRooms - noOfRooms;
                return new Status()
                {
                    ApiStatus = ApiStatus.Success,
                    StatusCode = 200,
                    StatusMessage = noOfRooms+" rooms booked!"
                };
            }
            catch (IDNotFoundException exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.NotFound,
                    StatusCode = 404,
                    StatusMessage = exception.Message
                };
            }
            catch (NotEnoughRoomsException exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.Failiure,
                    StatusCode = 400,
                    StatusMessage = exception.Message
                };
            }
            catch (Exception exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.Failiure,
                    StatusCode = 500,
                    StatusMessage = "Internal Server Error!"
                };
            }
        }

        // DELETE: api/Hotel/5
        public Status Delete(int id)
        {
            try
            {
                Hotel hotel = hotels.Find(temp => temp.Id == id);
                if (hotel == null)
                    throw new IDNotFoundException(id);
                hotels.Remove(hotel);
                return new Status()
                {
                    ApiStatus = ApiStatus.Success,
                    StatusCode = 200,
                    StatusMessage = "Hotel Deleted!"
                };
            }
            catch(IDNotFoundException exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.NotFound,
                    StatusCode = 404,
                    StatusMessage = exception.Message
                };
            }
            catch(Exception exception)
            {
                return new Status()
                {
                    ApiStatus = ApiStatus.Failiure,
                    StatusCode = 500,
                    StatusMessage = "Internal Server Error!"
                };
            }
        }
    }
}
