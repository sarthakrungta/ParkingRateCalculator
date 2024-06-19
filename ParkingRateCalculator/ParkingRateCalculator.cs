namespace ParkingRateCalculator
{
    public class ParkingRateCalculator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter entry date and time (yyyy-MM-dd HH:mm) in 24 hour format like '2024-06-18 22:45': ");
            DateTime entryDateTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter exit date and time (yyyy-MM-dd HH:mm) in 24 hour format like '2024-06-20 08:45': ");
            DateTime exitDateTime = DateTime.Parse(Console.ReadLine());

            var rate = CalculateRate(entryDateTime, exitDateTime);
            Console.WriteLine($"Rate Name: {rate.Item1}, Total Price: ${rate.Item2}");
        }

        public static Tuple<string, double> CalculateRate(DateTime entry, DateTime exit)
        {
            //Check if special rates are applicable
            if (IsNightRate(entry, exit))
                return new Tuple<string, double>("Night Rate", 6.50);

            if (IsWeekendRate(entry, exit))
                return new Tuple<string, double>("Weekend Rate", 10.00);

            if (IsEarlyBirdRate(entry, exit))
                return new Tuple<string, double>("Early Bird", 13.00);

            return CalculateStandardRate(entry, exit);
        }

        static bool IsWeekendRate(DateTime entry, DateTime exit)
        {
            return (entry.DayOfWeek == DayOfWeek.Saturday ||
                   entry.DayOfWeek == DayOfWeek.Sunday) && exit.DayOfWeek == DayOfWeek.Sunday;
        }

        static bool IsEarlyBirdRate(DateTime entry, DateTime exit)
        {
            return entry.TimeOfDay >= new TimeSpan(6, 0, 0) && entry.TimeOfDay <= new TimeSpan(9, 0, 0) &&
                   exit.TimeOfDay >= new TimeSpan(15, 30, 0) && exit.TimeOfDay <= new TimeSpan(23, 30, 0) &&
                   entry.Date == exit.Date;
        }

        static bool IsNightRate(DateTime entry, DateTime exit)
        {
            return entry.TimeOfDay >= new TimeSpan(18, 0, 0) && entry.TimeOfDay <= new TimeSpan(23, 59, 59) &&
                   exit.TimeOfDay <= new TimeSpan(6, 0, 0) &&
                   entry.Date == exit.Date.AddDays(-1);
        }

        static Tuple<string, double> CalculateStandardRate(DateTime entry, DateTime exit)
        {
            TimeSpan duration = exit - entry;
            double totalCost;

            if (duration.TotalHours <= 1)
                totalCost = 5.00;
            else if (duration.TotalHours <= 2)
                totalCost = 10.00;
            else if (duration.TotalHours <= 3)
                totalCost = 15.00;
            else
            {
                // Calculate the flat rate for each day
                totalCost = 20.00;
                DateTime newEntry = entry.Date.AddDays(1);
                while (newEntry <= exit.Date)
                {
                    totalCost += 20.00;
                    newEntry = newEntry.AddDays(1);
                }
            }

            return new Tuple<string, double>("Standard Rate", totalCost);
        }
    }
}