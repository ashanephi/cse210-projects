// This program meets and exceeds the design requirements through the following implementations:
//
// Where I've shown Creativity and Exceeded Requirements:
// - Gamification Elements: A leveling system, XP points, and coins create a more engaging experience.
// - Motivational Messages: Random motivational quotes inspire users after recording events.
// - Colorful Celebrations: Vibrant console colors.
// - Enhanced User Experience: The gamification layer and colorful feedback turn goal tracking into a fun, interactive quest.
// - Logging: Records program initialization to track startup events for debugging and monitoring

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        Logger.Log("Program Initialised.");
        manager.Start();
    }
}
