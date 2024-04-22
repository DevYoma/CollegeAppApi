namespace CollegeApp.MyLogging
{
    public class LogToServerMemory: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Log to server memory");
            // write Logic to write to server memory
        }
    }
}
