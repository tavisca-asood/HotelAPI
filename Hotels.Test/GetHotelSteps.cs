using System;
using TechTalk.SpecFlow;
using Hotels.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace Hotels.Test
{
    [Binding]
    public class GetHotelSteps
    {
        private List<Hotel> hotelResponse = new List<Hotel>();
        private bool IdFound;
        [When(@"User calls GetHotels api")]
        public void WhenUserCallsGetHotelsApi()
        {
            hotelResponse = new List<Hotel>();
        }

        [Then(@"User should see a list of all the hotels available")]
        public void ThenUserShouldSeeAListOfAllTheHotelsAvailable()
        {
            hotelResponse = HotelsApiCaller.GetHotels();
        }

        [Given(@"User has provided a valid Id '(.*)'")]
        public void GivenUserHasProvidedAValidId(int id)
        {
            hotelResponse.Find(x => x.Id == id).Should().NotBeNull();
        }

        [Given(@"User wants to get the details of the hotel with the particular Id")]
        public void GivenUserWantsToGetTheDetailsOfTheHotelWithTheParticularId()
        {
            if (IdFound == false)
                return;

        }

        [Then(@"User gets the hotel with the particular Id")]
        public void ThenUserGetsTheHotelWithTheParticularId()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
