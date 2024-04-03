namespace CollegeApp.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>() {
            new Student
            {
                Id = 1,
                StudentName = "Ogheneyoma", 
                Email = "lawrenceyoma@gmail.com", 
                Address = "Remote"
            }, 
            new Student
            {
                Id=2,
                StudentName = "Michael", 
                Email = "michael@gmail.com", 
                Address = "Lagos"
            }
        };
    }
}
