using System;
using TechTalk.SpecFlow;
using Hotels.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace Hotels.Test
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private List<Hotel> hotelResponse = new List<Hotel>();
        [Given(@"User provided valid Name '(.*)' and City '(.*)' for hotel")]
        public void GivenUserProvidedValidNameForHotel(string name,string city)
        {
            hotel.Name = name;
            hotel.Address = city;
        }
        
        [Given(@"User has added required details for the hotel")]
        public void GivenUserHasAddedRequioredDetailsForTheHotel()
        {
            SetHotelBasicDetails();
        }
        
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotelResponse = HotelsApiCaller.AddHotel(hotel);
        }
        
        [Then(@"Hotel with '(.*)' should be present in the response")]
        public void ThenHotelWithShouldBePresentInTheResponse(string name)
        {
            hotel = hotelResponse.Find(h => h.Name.Equals(name));
            hotel.Should().NotBeNull(string.Format("Hotel {0} not found in response", name));
        }

        private void SetHotelBasicDetails()
        {
            hotel.CityCode = "PNQ";
            hotel.AvailableRooms = 40;
        }

    }
}
