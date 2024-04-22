namespace CollegeApp.MyLogging
{
    public class LogToDB: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogtoDB");
            // write logic to save data to DB
        }
    }
}
