namespace CollegeApp.MyLogging
{
    public class LogToFile: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Log to file");
            // write logic to write to file
        }
    }
}
