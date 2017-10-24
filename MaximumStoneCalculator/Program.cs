using System;

namespace MaximumStoneCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StoneCalculator calc = new StoneCalculator();
            int estimatedLogsPerDay = calc.CalculateEstimatedLogsPerDay();
            int estimatedStonePerDay = calc.CalculateEstimatedStonePerDay();

            //Console.WriteLine($"Estimated Logs: {estimatedLogsPerDay}");
            //Console.WriteLine($"Estimated Stone: {estimatedStonePerDay}");

            //calc.CalculateAllCombos();
            //calc.GoThrough30Days();
            calc.GoThrough30DaysOfCombos();
            Console.Read();
        }
    }
}
