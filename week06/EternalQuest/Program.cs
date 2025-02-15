class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        Logger.Log("Program Initialised.");
        manager.Start();
    }
}
