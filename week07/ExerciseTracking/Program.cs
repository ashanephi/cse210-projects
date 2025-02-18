using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 3), 40, 20),
            new Running(new DateTime(2024, 06, 18), 35, 4.8),
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}