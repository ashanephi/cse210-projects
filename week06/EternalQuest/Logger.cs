public class Logger
{
    private static string logFilePath = $"eternalquest_log_{DateTime.Now:yyyyMMdd}.txt";

    public static void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
