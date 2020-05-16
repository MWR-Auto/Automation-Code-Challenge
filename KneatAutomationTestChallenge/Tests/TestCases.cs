#region usings

using NUnit.Framework;
using System.Threading;

#endregion

#region TestCases

namespace KneatAutomationTestChallenge.Tests
{
    [TestFixture]
    public class TestCases : TestsTemplate
    {

        [TestCase()]
        public void SaunaTaskVerification()
        {
            var BookingInfo = SetData("Limerick", 1, 2, 0, 3, 1, "Sauna");
            HotelToFind = "Limerick Strand Hotel";
            HotelUnableToFind = "George Limerick Hotel";

            FillWithSampleData(BookingInfo);

            FindAndNavigate(true, "//*[@id=\"filter_popular_activities\"]//*[contains(text(),'" + BookingInfo.Spa + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);
            VerifyIfHotelIsVisible(HotelToFind, true);
            VerifyIfHotelIsVisible(HotelUnableToFind, false);
        }

        [TestCase]
        public void FiveStarsTaskVerification()
        {
            var BookingInfo = SetData("Limerick", 1, 2, 0, 3, 1, string.Empty, 5);
            HotelToFind = "The Savoy Hotel";
            HotelUnableToFind = "George Limerick Hotel";

            FillWithSampleData(BookingInfo);

            FindAndNavigate(true, "//*[@id=\"filter_class\"]//*[contains(text(),'" + BookingInfo.HowManyStars + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);
            VerifyIfHotelIsVisible(HotelToFind, true);
            VerifyIfHotelIsVisible(HotelUnableToFind, false);
        }

        [TestCase]
        public void FourStarsVerificationWithDificultData()
        {
            var BookingInfo = SetData("Limerick", 2, 2, 1, 4, 1, string.Empty, 4);
            HotelToFind = "Clayton Hotel Limerick";
            HotelUnableToFind = "The Pier Hotel";

            FillWithSampleData(BookingInfo);

            FindAndNavigate(true, "//*[@id=\"filter_class\"]//*[contains(text(),'" + BookingInfo.HowManyStars + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);
            VerifyIfHotelIsVisible(HotelToFind, true);
            VerifyIfHotelIsVisible(HotelUnableToFind, false);
        }

        [TestCase]
        public void SaunaAndFourStars()
        {
            var BookingInfo = SetData("Limerick", 2, 2, 1, 4, 1, "Sauna", 4);

            HotelToFind = "Clayton Hotel Limerick";
            HotelUnableToFind = "The Inn at Dromoland";

            FillWithSampleData(BookingInfo);
            FindAndNavigate(true, "//*[@id=\"filter_popular_activities\"]//*[contains(text(),'" + BookingInfo.Spa + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);
            FindAndNavigate(true, "//*[@id=\"filter_class\"]//*[contains(text(),'" + BookingInfo.HowManyStars + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);

            VerifyIfHotelIsVisible(HotelToFind, true);
            VerifyIfHotelIsVisible(HotelUnableToFind, false);
        }

        [TestCase]
        public void FitnessCheck()
        {
            var BookingInfo = SetData("Limerick", 2, 2, 1, 4, 1, "Fitness");

            HotelToFind = "Clayton Hotel Limerick";
            HotelUnableToFind = "The Inn at Dromoland";

            FillWithSampleData(BookingInfo);
            FindAndNavigate(true, "//*[@id=\"filter_popular_activities\"]//*[contains(text(),'" + BookingInfo.Spa + "')]", xpath);
            //Just too make Sure.
            Thread.Sleep(10000);

            VerifyIfHotelIsVisible(HotelToFind, true);
            VerifyIfHotelIsVisible(HotelUnableToFind, false);
        }
    }
}

#endregion