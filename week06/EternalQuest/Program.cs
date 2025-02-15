// This program meets and exceeds the design requirements through the following implementations:
//
// Design Requirements:
// - Inheritance: A base class 'Goal' is used with derived classes for each type of goal (SimpleGoal, EternalGoal, ChecklistGoal), ensuring that the shared attributes and behaviors are managed in one place.
// - Polymorphism: Derived classes override base class methods, like 'RecordEvent()' and 'IsComplete()', allowing each goal type to implement its unique behavior.
// - Encapsulation and Abstraction: Private member variables are used to protect data, and related methods are grouped within each class, whereby it promoting maintainability and clarity.
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
