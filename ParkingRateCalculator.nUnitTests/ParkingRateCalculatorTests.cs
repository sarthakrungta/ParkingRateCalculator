namespace ParkingRateCalculator.nUnitTests
{
    public class ParkingRateCalculatorTests
    {

        [TestCase("2024-06-14 06:30", "2024-06-14 16:00")]
        [TestCase("2024-06-18 08:59", "2024-06-18 23:20")]
        [TestCase("2024-06-17 07:26", "2024-06-17 15:30")]
        public void EarlyBirdParking_EqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Early Bird", 13);

            //Comparison with Expected Output
            Assert.That(rate, Is.EqualTo(expectedRate));
        }


        [TestCase("2024-06-14 06:00", "2024-06-14 23:34")]
        [TestCase("2024-06-16 07:26", "2024-06-16 20:45")] //Qualifies for Early Bird as well but Weekend rate takes presedence
        [TestCase("2024-06-18 09:11", "2024-06-18 10:00")]
        [TestCase("2024-06-16 05:00", "2024-06-16 09:45")]
        public void EarlyBirdParking_NotEqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Early Bird", 13);

            //Comparison with Expected Output
            Assert.That(rate, Is.Not.EqualTo(expectedRate));
        }

        [TestCase("2024-06-16 07:26", "2024-06-16 20:45")]
        [TestCase("2024-06-15 00:00", "2024-06-16 23:20")]
        public void WeekendParking_EqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Weekend Rate", 10);

            //Comparison with Expected Output
            Assert.That(rate, Is.EqualTo(expectedRate));
        }


        [TestCase("2024-06-14 10:00", "2024-06-16 23:34")]
        [TestCase("2024-06-18 09:11", "2024-06-19 11:00")]
        [TestCase("2024-06-15 02:05", "2024-06-17 00:01")]
        public void WeekendParking_NotEqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Weekend Rate", 10);

            //Comparison with Expected Output
            Assert.That(rate, Is.Not.EqualTo(expectedRate));
        }

        [TestCase("2024-06-19 18:26", "2024-06-20 05:45")]
        [TestCase("2024-06-14 22:00", "2024-06-15 02:20")]
        public void NightParking_EqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Night Rate", 6.5);

            //Comparison with Expected Output
            Assert.That(rate, Is.EqualTo(expectedRate));
        }


        [TestCase("2024-06-14 10:00", "2024-06-16 23:34")]
        [TestCase("2024-06-18 09:11", "2024-06-19 11:00")]
        [TestCase("2024-06-15 02:05", "2024-06-17 00:01")]
        public void NightParking_NotEqualTest(String entry, String exit)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Night Rate", 6.5);

            //Comparison with Expected Output
            Assert.That(rate, Is.Not.EqualTo(expectedRate));
        }

        [TestCase("2024-06-18 08:26", "2024-06-20 14:45", 60)]
        [TestCase("2024-06-14 22:00", "2024-06-14 23:20", 10)]
        [TestCase("2024-06-10 04:00", "2024-06-19 18:20", 200)]
        public void StandardParking_EqualTest(String entry, String exit, double expectedValue)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Standard Rate", expectedValue);

            //Comparison with Expected Output
            Assert.That(rate, Is.EqualTo(expectedRate));
        }


        [TestCase("2024-06-14 06:30", "2024-06-14 16:00", 20)]
        [TestCase("2024-06-16 07:26", "2024-06-16 20:45", 100)]
        [TestCase("2024-06-14 22:00", "2024-06-15 02:20", 40)]
        public void StandardParking_NotEqualTest(String entry, String exit, double expectedValue)
        {
            //Fetch Date Times from Test Variable
            var entryDateTime = DateTime.Parse(entry);
            var exitDateTime = DateTime.Parse(exit);

            //Run Rate Calculator Method on input
            var rate = ParkingRateCalculator.CalculateRate(entryDateTime, exitDateTime);
            Tuple<string, double> expectedRate = new Tuple<string, double>("Standard Rate", expectedValue);

            //Comparison with Expected Output
            Assert.That(rate, Is.Not.EqualTo(expectedRate));
        }
    }
}