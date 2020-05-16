#region usings

using System;

#endregion

#region InformationAboutBook
namespace KneatAutomationTestChallenge.Tests
{
    public class InformationAboutBook
    {
        public string Destination { get; set; }
        public int Room { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int HowManyStars { get; set;  }
        public int HowManyMonthsFromTodayDate { get; set; }
        public int HowManyDaysToCheckOut { get; set; }
        public string Spa { get; set; }
        public DateTime CheckInDate { get { return DateTime.Now.AddMonths(HowManyMonthsFromTodayDate); } }
        public DateTime CheckOutDate { get { return DateTime.Now.AddMonths(HowManyMonthsFromTodayDate).AddDays(HowManyDaysToCheckOut); } }
    }
}

#endregion